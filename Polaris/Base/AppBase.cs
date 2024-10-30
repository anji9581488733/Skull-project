using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;

namespace Polaris.Base
{
    /// <summary>
    /// Provides utility functions for managing applications and ports.
    /// </summary>
    public class AppBase
    {
        /// <summary>
        /// Executes a shell command without returning any output.
        /// </summary>
        /// <param name="command">The command to execute.</param>
        public static void ExecuteCommand(string command)
        {var processInfo = new ProcessStartInfo
            {
                FileName = AppSettings.IsWindows ? "cmd.exe" : "/bin/bash",
                Arguments = AppSettings.IsWindows ? $"/c {command}" : $"-c \"{command}\"",
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardError = true,
                RedirectStandardOutput = true
            };

            using (var process = Process.Start(processInfo))
            {
                process.WaitForExit();
            }
        }

        /// <summary>
        /// Executes a shell command and returns the output as a string.
        /// </summary>
        /// <param name="command">The command to execute.</param>
        /// <returns>The output from the shell command.</returns>
        public static string ExecuteCommandAndReturnOutput(string command)
        {
            var processInfo = new ProcessStartInfo
            {
                FileName = AppSettings.IsWindows ? "cmd.exe" : "/bin/bash",
                Arguments = AppSettings.IsWindows ? $"/c {command}" : $"-c \"{command}\"",
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardError = true,
                RedirectStandardOutput = true
            };

            using (var process = Process.Start(processInfo))
            {
                if (process == null)
                {
                    throw new InvalidOperationException("Failed to start the process.");
                }

                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();
                process.WaitForExit();

                if (process.ExitCode != 0)
                {
                    throw new InvalidOperationException($"Command `{command}` exited with code {process.ExitCode}. Error: {error}");
                }

                return output;
            }
        }

        /// <summary>
        /// Checks if a given port is in use.
        /// </summary>
        /// <param name="port">The port to check.</param>
        /// <returns>True if the port is in use, false otherwise.</returns>
        public static bool IsPortInUse(int port)
        {
            try
            {
                var listener = new TcpListener(IPAddress.Any, port);
                listener.Start();
                listener.Stop();
            }
            catch (SocketException ex)
            {
                if (ex.SocketErrorCode == SocketError.AddressAlreadyInUse)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Parses the output from a command to find a process ID (PID).
        /// </summary>
        /// <param name="input">The command output containing the PID information.</param>
        /// <returns>The PID if found, null otherwise.</returns>
        public static int? GetPID(string input)
        {
            var match = Regex.Match(input, @"\bnode\s+(\d+)\b");
            if (match.Success)
            {
                if (int.TryParse(match.Groups[1].Value, out int pidValue))
                {
                    return pidValue;
                }
            }

            return null;
        }

        public static bool ReleasePort(int port)
        {
            string processesOnPort = ExecuteCommandAndReturnOutput($"lsof -i :{port}");
            int? pid = GetPID(processesOnPort);
            if (pid.HasValue)
            {
                try
                {
                    ExecuteCommand($"kill -9 {pid.Value}");

                    // Wait for the process to exit
                    int maxWaitMillis = 5000; // Maximum wait time of 5 seconds
                    int checkIntervalMillis = 500; // Check every 500 milliseconds
                    int waitedMillis = 0;
                    while (waitedMillis < maxWaitMillis && IsPortInUse(port))
                    {
                        System.Threading.Thread.Sleep(checkIntervalMillis);
                        waitedMillis += checkIntervalMillis;
                    }

                    if (IsPortInUse(port))
                    {
                        Console.WriteLine($"Process with PID {pid.Value} could not be killed, or port {port} is still in use.");
                        return false;
                    }
                    else
                    {
                        Console.WriteLine($"Process with PID {pid.Value} has been successfully killed and port {port} is released.");
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred while trying to kill the process: {ex.Message}");
                    return false;
                }
            }
            else
            {
                Console.WriteLine($"No process found listening on port {port}.");
                return true; // Returning true because the port is not in use
            }
        }
    }
}