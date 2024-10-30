Feature: Component test
This feature file is used to hold Component Test test cases for automated execution !!!!!
Used for running unit tests for Dev for NAP test 
	
	@ComponentTest @Example
	Scenario: Verify ComponentTest Plugin
		Given I launch the plugin app
		When I scroll 'Down' to and press 'ComponentTest. ComponentTestPlugin'
		Then Validate the result on Component Test page
	
	@ComponentTest @Example
	Scenario: Verify ComponentTest Plugin with GRANT Permissions if exist
		Given I launch the plugin app
		When I scroll 'Down' to and press 'ComponentTest. ComponentTestPlugin'
		And I scroll 'Down' and press 'PermissionRequestGrantedComponentTests' on 'ComponentTestPage' if exists
		And I scroll 'Up' and press 'ComponentTestState' on 'ComponentTestPage'
		And I press 'Run selected' on 'ComponentTestPage'
		And I 'GRANT' all access permission requests
		Then Validate the result on Component Test page
		
	@ComponentTest @Example
	Scenario: Verify ComponentTest Plugin with DENY Permissions if exist
		Given I launch the plugin app
		When I scroll 'Down' to and press 'ComponentTest. ComponentTestPlugin'
		And I scroll 'Down' and press 'PermissionRequestDeniedComponentTests' on 'ComponentTestPage' if exists
		And I scroll 'Up' and press 'ComponentTestState' on 'ComponentTestPage'
		And I press 'Run selected' on 'ComponentTestPage'
		And I 'DENY' all access permission requests
		Then Validate the result on Component Test page