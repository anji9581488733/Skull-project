import os
import sys


def read_environment_properties(properties_path):
    env_details = {}
    try:
        with open(properties_path, 'r') as file:
            for line in file:
                line = line.strip()
                if "=" in line:
                    key, value = line.split('=', 1)
                    env_details[key.strip()] = value.strip()
    except FileNotFoundError:
        print(f"Error: File not found at {properties_path}")
        sys.exit(1)

    return env_details


def construct_properties_path():
    current_dir = os.getcwd()
    base_path = os.path.dirname(current_dir)
    properties_path = os.path.join(base_path, 'nap-test-framework', 'Fenris', 'bin', 'Release', 'net8.0',
                                   'allure-results', 'environment.properties')
    print(properties_path)  # For debugging
    return properties_path


def main():
    properties_path = construct_properties_path()
    env_details = read_environment_properties(properties_path)
    properties_string = ""
    for key, value in env_details.items():
        if key == "Additional Details":
            value = format_additional_details(value)
        properties_string += f"{key}: {value}\n"
    # Sanitize and format for environment variable
    sanitized_details = properties_string.replace('\n', ' ').replace(':', ';')
    with open(os.getenv('GITHUB_ENV'), 'a') as env_file:
        env_file.write(f"ADDITIONAL_DETAILS={sanitized_details}\n")


def format_additional_details(details):
    details_list = details.split(' ')
    formatted_details = ' '.join(details_list)
    return formatted_details


if __name__ == "__main__":
    main()
