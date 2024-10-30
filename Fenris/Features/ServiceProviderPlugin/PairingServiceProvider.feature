Feature: Pariring Service Provider
This feature file is used to hold Component Test test cases for automated execution !!!!!
Used for running unit tests for Dev for NAP test 

@ServiceProviderTest @Example @BluetoothPermission @LocationPermission
Scenario Outline: Verify Location and Bluetooth Services when allowing and Denying until app is sent to background location permissions
	Given I launch the plugin app
	And I am in Dynamic service provider page after enabling 'Use Dynamic Service Provider'
	When I select '<ServiceProvider>' Service provider and base as '<ServiceProviderBase>' and plugin as '<PluginName>' for '<Service>'
	And I press 'Ok' in service configuration 
	And I press 'Allow' button in service configuration 
	Then Validate '<ValidationName>' is displayed
	When I press Close button from header
	And I scroll 'Down' to and press 'Pairing. PairingPlugin'
	And I press 'Ok' in service configuration 
	And I press 'Deny until app is sent to background.' button in service configuration
	And I press '<SettingsText>' button in multi page
	And I launch the plugin app
	Then Validate '<ValidationName>' is displayed
	And Validate Back button is 'not displayed' for Service Provider from header

	Examples:
	| Service   | ServiceProvider                  | ServiceProviderBase                                        | PluginName                               | SettingsText  | ValidationName                                                                             |
	| Location  | IPairingServiceProvider          | PairingServiceProviderTestDoubleForLocationPermissionFlow  | Pairing. PairingPlugin                   | Open settings | Allow Bluetooth                                                                            |
	| Bluetooth | IPairingServiceProvider          | PairingServiceProviderTestDoubleForBluetoothPermissionFlow | Pairing. PairingPlugin                   | Open Settings | In order to connect to your hearing aids your mobile device has to have Bluetooth enabled. |
 

@ServiceProviderTest @Example @BluetoothPermission @LocationPermission
Scenario Outline: Verify Location and Bluetooth Services when denying location permissions
	Given I launch the plugin app
	And I am in Dynamic service provider page after enabling 'Use Dynamic Service Provider'
	When I select '<ServiceProvider>' Service provider and base as '<ServiceProviderBase>' and plugin as '<PluginName>' for '<Service>'
	And I press 'Ok' in service configuration 
	And I press 'Deny' button in service configuration 
	Then Validate '<SettingsText>' is displayed
	When I press '<SettingsText>' button in multi page
	Then Validate 'Settings' text is displayed on Native Settings Page
		
Examples:
  | Service   | ServiceProvider         | ServiceProviderBase                                        | PluginName             | SettingsText  |
  | Location  | IPairingServiceProvider | PairingServiceProviderTestDoubleForLocationPermissionFlow  | Pairing. PairingPlugin | Open settings |
  | Bluetooth | IPairingServiceProvider | PairingServiceProviderTestDoubleForBluetoothPermissionFlow | Pairing. PairingPlugin | Open Settings | 

	@ServiceProviderTest @Example @AirplaneModePermission
	Scenario Outline: Verify Toggle Airplane mode 
		Given I launch the plugin app
		And I am in Dynamic service provider page after enabling 'Use Dynamic Service Provider'
		When I select '<ServiceProvider>' Service provider and base as '<ServiceProviderBase>' and plugin as '<PluginName>' for '<Service>'
		And I press 'Ok' in service configuration 
		And I press 'Allow' button in service configuration 
		Then Validate 'Ready for takeoff?' is displayed
		And Validate 'Before we begin please enable and disable airplane mode to ensure your phone can find your hearing aids without problems' is displayed
		And Validate Back button is 'not displayed' for Service Provider from header
		When I press 'Show me how' button in multi page
		Then Validate 'Airplane mode' text is displayed on Native Settings Page
		And Validate Back button is 'Displayed' for Service Provider from header
		
		Examples:
		  | Service      | ServiceProvider         | ServiceProviderBase    | PluginName             | SettingsText  |
		  | AirplaneMode | IPairingServiceProvider | PairingServiceProvider | Pairing. PairingPlugin | Open settings |
		  
@ServiceProviderTest @Example @CameraPermission
Scenario: Verify Camera Services using dynamic service provider
	Given I launch the plugin app
	And I am in Dynamic service provider page after enabling 'Use Dynamic Service Provider'
	When I select 'ICameraPermissionServiceProvider' Service provider and base as 'CameraPermissionServiceProviderTestDouble' and plugin as 'CameraPermission. CameraPermissionPlugin' for 'Camera'
	And I press 'OK' in service configuration 
	And I press 'Allow while service is running.' button in service configuration 
	And I scroll 'Down' to and press 'CameraPermission. CameraPermissionPlugin'
	And I press 'OK' in service configuration 
	And I press 'Deny while app is running.' button in service configuration
	And I scroll 'Down' to and press 'CameraPermission. CameraPermissionPlugin'
	And I press 'Open settings' button in multi page
	Then Validate 'Settings' text is displayed on Native Settings Page


