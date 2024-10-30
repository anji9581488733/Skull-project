Feature: NativeSettings
Allow change native settings
	
	@Example
	Scenario: Test for switching apps
		Given I launch the plugin app
		When I scroll 'Down' to and press 'POCConsent. POCConsentPlugin'
		Given Go to native settings
		When I scroll 'Down' and press 'Bluetooth' on 'NativeSettingsPage'
		Given I launch the plugin app
		Then The following elements are displayed on 'ConsentPart1Page'
		  | Element                      | ShouldBeDisplayed |
		  | ConsentPart1Header           | true              |
		  | ConsentPart1Body1            | true              |
		  | ConsentPart1Body2            | true              |
		  | ScrollToBottomPart1          | true              |
		  | AcceptAndContinuePart1Button | false             |
		  | DeclineConsentPart2          | false             |
		Given Go to native settings
		When I turn 'OFF' Bluetooth
		When I turn 'ON' Bluetooth
		
	@Example @Settings @iOS
	Scenario: Open native settings
		Given Go to native settings
	
	@Example @Settings @iOS
	Scenario: Turn OFF Bluetooth
		Given Go to native settings
		When I press 'Bluetooth' button on Settings Page
		When I turn 'OFF' Bluetooth
		Then Check if Bluetooth is 'OFF'
		
	@Example @Settings @iOS
	Scenario: Turn ON Bluetooth
		Given Go to native settings
		When I press 'Bluetooth' button on Settings Page
		When I turn 'ON' Bluetooth
		Then Check if Bluetooth is 'ON'
		
	@Example @Settings @iOS @CheckIfHIAreAlreadyPaired @suite:PreEvents
	Scenario: Verify if specified HI are already Paired
		Given Go to native settings
		When I scroll 'Down' and press 'Accessibility' on 'NativeSettingsPage'
		When I scroll 'Down' and press 'Hearing Devices' on 'NativeAccessibilityPage'
		Then Verify if specified Hearing Instruments are already Paired
		
	@Example @Settings @iOS @ForgetPairedHIs @suite:PostEvents
	Scenario: Forget paired HI
		Given Go to native settings
		When I scroll 'Down' and press 'Accessibility' on 'NativeSettingsPage'
		When I scroll 'Down' and press 'Hearing Devices' on 'NativeAccessibilityPage'
		Then Verify if specified Hearing Instruments are already Paired
		When I press 'HINameFromConfig' on 'NativeHearingDevices'
		When I scroll 'Down' with '1' full-screen scrolls
		And I press 'Forget this device' on 'NativeHiMenu'
		When I press 'Forget' on 'NativeHiMenu'
			
	@Example @Settings @iOS @Smoke @CreateNewPairWithHI @suite:PreEvents
	Scenario: New pairing with HI
		Given Go to native settings
		When I scroll 'Down' and press 'Accessibility' on 'NativeSettingsPage'
		When I initialize the hearing aids through HIC
		When I reboot the hearing aids through HIC
		Then I wait '30' seconds
		When I scroll 'Down' and press 'Hearing Devices' on 'NativeAccessibilityPage'
		When I press 'HINameFromConfig' on 'NativeHearingDevices'
		When I press Pair on alert
		When I press Pair on alert
	
	@Example @Settings @Android @Smoke
	Scenario: Enable Bluetooth on Mobile
		Given Go to native settings
		When I turn 'ON' Bluetooth