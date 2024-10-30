Feature: Pairing - MFi Already Paired flow
Flow has been prepared for TestSinglePlugin and TestMultiplePlugins
    
    @Pairing @MFiAlreadyPaired @label:allure_id:1670575 @tms:1670575 @parentSuite:Pairing @suite:MFiAlreadyPairedFlow @subSuite:UsingPrePairedHI @owner:QA
    Scenario: Execute MFi already paired flow - (Simple flow to pass the pairing flow successfully)
        Given I launch the plugin app
        When I scroll 'Down' to and press 'Pairing. PairingPlugin'
        When I press 'Ok' on 'AllowBluetoothPage'
        And I press 'AllowBluetoothPopup' on 'AllowBluetoothPage'
        And I press 'Done' on 'ToggleAirplaneModePage'
        And I press 'Use these' on 'MFiFullyConnectedPage'
        Then The following elements are displayed on 'ConnectingPage'
            | Element                                   | ShouldBeDisplayed |
            | Connecting...                             | true              |
            | The app is connecting to the hearing aids | true              |
        When I press 'Continue' on 'WaitingForBootPage'
        And I initialize the hearing aids through HIC
        And I reboot the hearing aids through HIC
        When I press 'Continue' on 'TrustedBondCompletedPage' with timeout '60'
        Then Validate 'Completed' text is displayed on the Display Message plugin page
        When I press Close button on Display Message plugin
        Then Validate 'Closed' text is displayed on the Display Message plugin page
        
    @Pairing @MFiAlreadyPaired @label:allure_id:1670576 @tms:1670576 @parentSuite:Pairing @suite:MFiAlreadyPairedFlow @subSuite:UsingPrePairedHI @owner:QA
    Scenario: Execute MFi Already Paired Flow with Airplane Mode Reset - (Simple flow to pass pairing flow successfully with airplane mode activation)
        Given I launch the plugin app
        When I scroll 'Down' to and press 'Pairing. PairingPlugin'
        When I press 'Ok' on 'AllowBluetoothPage'
        And I press 'AllowBluetoothPopup' on 'AllowBluetoothPage'
        Given Go to native settings
        When I turn 'ON' Airplane Mode
        And I turn 'OFF' Airplane Mode
        Given I launch the plugin app
        When I press 'Done' on 'ToggleAirplaneModePage'
        And I press 'Use these' on 'MFiFullyConnectedPage'
        Then The following elements are displayed on 'ConnectingPage'
            | Element                                   | ShouldBeDisplayed |
            | Connecting...                             | true              |
            | The app is connecting to the hearing aids | true              |
        When I press 'Continue' on 'WaitingForBootPage'
        And I initialize the hearing aids through HIC
        And I reboot the hearing aids through HIC
        When I press 'Continue' on 'TrustedBondCompletedPage' with timeout '60'
        Then Validate 'Completed' text is displayed on the Display Message plugin page
        When I press Close button on Display Message plugin
        Then Validate 'Closed' text is displayed on the Display Message plugin page
        
    @Pairing @MFiAlreadyPaired @label:allure_id:1670577 @tms:1670577 @parentSuite:Pairing @suite:MFiAlreadyPairedFlow @subSuite:UsingPrePairedHI @owner:QA
    Scenario: Check all elements In MFi Already Paired Flow - (Extended flow to successfully pass the pairing flow and check all items along the way)
        Given I launch the plugin app
        When I press 'Close Button' on Assembly List Plugin Page
        And I press 'StartPluginButton' button to start the Single Plugin
        When I scroll 'Down' to and press 'Pairing. PairingPlugin'
        Then The following elements are displayed on 'AllowBluetoothPage'
            | Element             | ShouldBeDisplayed |
            | Allow Bluetooth     | true              |
            | In order to connect | true              |
        When I press 'Ok' on 'AllowBluetoothPage'
        And I press 'AllowBluetoothPopup' on 'AllowBluetoothPage'
        Then The following elements are displayed on 'ToggleAirplaneModePage'
            | Element            | ShouldBeDisplayed |
            | Ready for takeoff? | true              |
            | Before we begin    | true              |
            | Show me how        | true              |
        When I press 'Done' on 'ToggleAirplaneModePage'
        Then The following elements are displayed on 'MFiFullyConnectedPage'
            | Element                                        | ShouldBeDisplayed |
            | Use connected                                  | true              |
            | [HI NAME] are connected                        | true              |
            | Show me how                                    | true              |
            | No, remove and pair new" => NoRemoveAndPairNew | true              |
        When I press 'Use these' on 'MFiFullyConnectedPage'
        Then The following elements are displayed on 'ConnectingPage'
            | Element                                   | ShouldBeDisplayed |
            | Connecting...                             | true              |
            | The app us connecting to the hearing aids | true              |
        Then The following elements are displayed on 'WaitingForBootPage'
            | Element                 | ShouldBeDisplayed |
            | Connected               | true              |
            | Next step is to restart | true              |
        When I press 'Continue' on 'WaitingForBootPage'
        And I initialize the hearing aids through HIC
        And I reboot the hearing aids through HIC
        Then The following elements are displayed on 'TrustedBondCompletedPage' with timeout '60'
            | Element         | ShouldBeDisplayed |
            | Well done       | true              |
            | You are all set | true              |
        When I press 'Continue' on 'TrustedBondCompletedPage'
        Then Validate 'Completed' text is displayed on the Display Message plugin page
        When I press Close button on Display Message plugin
        Then Validate 'Closed' text is displayed on the Display Message plugin page
        
    @Pairing @MFiAlreadyPaired @label:allure_id:1670578 @tms:1670578 @parentSuite:Pairing @suite:MFiAlreadyPairedFlow @subSuite:WithoutHI @owner:QA
    Scenario: Check all elements on ToggleAirplaneModeGuidePage - (Check all the elements on page ToggleAirplaneModeGuide)
        Given I launch the plugin app
        When I press 'Close Button' on Assembly List Plugin Page
        And I press 'StartPluginButton' button to start the Single Plugin
        When I scroll 'Down' to and press 'Pairing. PairingPlugin'
        When I press 'Ok' on 'AllowBluetoothPage'
        And I press 'AllowBluetoothPopup' on 'AllowBluetoothPage'
        And I press 'Show me how' on 'ToggleAirplaneModePage'
        Then The following elements are displayed on 'ToggleAirplaneModeGuidePage'
            | Element                 | ShouldBeDisplayed |
            | Airplane mode           | true              |
            | To toggle airplane mode | true              |
            | Step1                   | true              |
            | Step2                   | true              |
            | Step3                   | true              |
        
    @Pairing @MFiAlreadyPaired @label:allure_id:1670579 @tms:1670579 @parentSuite:Pairing @suite:MFiAlreadyPairedFlow @subSuite:WithoutHI @owner:QA
    Scenario: Check All Elements On Connection Failed Page - Negative test (Check all the elements on page ConnectionFailed)
        Given I launch the plugin app
        When I press 'Close Button' on Assembly List Plugin Page
        And I press 'StartPluginButton' button to start the Single Plugin
        When I scroll 'Down' to and press 'Pairing. PairingPlugin'
        When I press 'Ok' on 'AllowBluetoothPage'
        And I press 'AllowBluetoothPopup' on 'AllowBluetoothPage'
        And I press 'Done' on 'ToggleAirplaneModePage'
        And I press 'Use these' on 'MFiFullyConnectedPage'
        Then The following elements are displayed on 'ConnectingPage'
            | Element                                   | ShouldBeDisplayed |
            | Connecting...                             | true              |
            | The app is connecting to the hearing aids | true              |
        When I press 'Continue' on 'WaitingForBootPage'
        Then I wait '120' seconds
        Then The following elements are displayed on 'ConnectionFailedPage'
            | Element                     | ShouldBeDisplayed |
            | Connection failed           | true              |
            | Your device failed          | true              |
            | Make sure your hearing aids | true              |
            | Try again                   | true              |
            | Need help?                  | true              |

    @Pairing @MFiAlreadyPaired @label:allure_id:1670580 @tms:1670580 @parentSuite:Pairing @suite:MFiAlreadyPairedFlow @subSuite:WithoutHI @owner:QA
    Scenario: Don't Allow Bluetooth Permission (Deny bluetooth permission and verify Application access in native settings)
        Given I launch the plugin app
        When I press 'Close Button' on Assembly List Plugin Page
        And I press 'StartPluginButton' button to start the Single Plugin
        When I scroll 'Down' to and press 'Pairing. PairingPlugin'
        When I press 'Ok' on 'AllowBluetoothPage'
        And I press 'DontAllowBluetoothPopup' on 'AllowBluetoothPage'
        And I press 'Open Settings' on 'AllowBluetoothFromAppSettingsPage'
        Then Verify if 'Allow APP To Access' label is visible
        
    @Pairing @MFiAlreadyPaired @label:allure_id:1670581 @tms:1670581 @parentSuite:Pairing @suite:MFiAlreadyPairedFlow @subSuite:WithoutHI @owner:QA
    Scenario: Don't Allow Bluetooth Permission And Check Visibility Of All Elements (Deny bluetooth permission and verify all elements in AllowBluetoothFromAppSettingsPage)
        Given I launch the plugin app
        When I press 'Close Button' on Assembly List Plugin Page
        And I press 'StartPluginButton' button to start the Single Plugin
        When I scroll 'Down' to and press 'Pairing. PairingPlugin'
        Then The following elements are displayed on 'AllowBluetoothPage'
            | Element             | ShouldBeDisplayed |
            | Allow Bluetooth     | true              |
            | In order to connect | true              |
        When I press 'Ok' on 'AllowBluetoothPage'
        When I press 'DontAllowBluetoothPopup' on 'AllowBluetoothPage'
        Then The following elements are displayed on 'AllowBluetoothFromAppSettingsPage'
            | Element            | ShouldBeDisplayed |
            | Allow Bluetooth    | true              |
            | Go to app settings | true              |
        When I press 'Open Settings' on 'AllowBluetoothFromAppSettingsPage'
        Then Verify if 'Allow Test Single Plugin To Access' label is visible