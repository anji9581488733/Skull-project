Feature: Visual Test
This feature file is used to Visual test !!!!!
Used for running unit tests for Dev for NAP test 

@Visualtest @Example
Scenario: Visual test POC for taking screenshot with scroll functionality
	Given I launch the plugin app
	When I scroll 'Down' to and press 'ComponentTest. ComponentTestPlugin'
	And Take screenshot with name 'Test'
	