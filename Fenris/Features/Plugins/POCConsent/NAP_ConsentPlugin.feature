Feature: NAP_ConsentPlugin
	
@normal @POCConsent @label:allure_id:1655572 @tms:1655572 @story:POCConsent @parentSuite:POCConsent @owner:QA
Scenario: Verify POCConsent Plugin Extended - (Extended test using tables to check visibility of multiple elements)
	Given I launch the plugin app
	When I scroll 'Down' to and press 'POCConsent. POCConsentPlugin'
	Then The following elements are displayed on 'ConsentPart1Page'
		| Element                      | ShouldBeDisplayed |
		| ConsentPart1Header           | true              |
		| ConsentPart1Body1            | true              |
		| ConsentPart1Body2            | true              |
		| ScrollToBottomPart1          | true              |
		| AcceptAndContinuePart1Button | false             |
		| DeclineConsentPart2          | false             |
	When I press 'ScrollToBottomPart1' on 'ConsentPart1Page'
	Then The following elements are displayed on 'ConsentPart1Page'
	    | Element                      | ShouldBeDisplayed |
	    | ConsentPart1Header           | false             |
		| ConsentPart1Body1            | false             |
		| ConsentPart1Body2            | true              |
		| ScrollToBottomPart1          | false             |
		| AcceptAndContinuePart1Button | true              |
	    | DeclineConsentPart2          | false             |
	When I press 'AcceptAndContinuePart1Button' on 'ConsentPart1Page'
	Then The following elements are displayed on 'ConsentPart2Page'
		| Element                      | ShouldBeDisplayed |
		| ConsentPart2Header           | true              |
		| ConsentPart2Body1            | true              |
		| ConsentPart2Body2            | true              |
		| ScrollToBottomPart2          | true              |
		| AcceptAndContinuePart2Button | false             |
		| DeclineConsentPart2          | false             |
	When I press 'ScrollToBottomPart2' on 'ConsentPart2Page'
	Then The following elements are displayed on 'ConsentPart2Page'
	  	| Element                      | ShouldBeDisplayed |
	    | ConsentPart2Header           | false             |
	    | ConsentPart2Body1            | false             |
	    | ConsentPart2Body2            | true              |
		| ScrollToBottomPart2          | false             |
	    | AcceptAndContinuePart2Button | true              |
	    | DeclineConsentPart2          | true              |
	When I press 'AcceptAndContinuePart2Button' on 'ConsentPart2Page'
	Then Validate 'Completed' text is displayed on the Display Message plugin page
	When I press Close button on Display Message plugin
	Then Validate 'Closed' text is displayed on the Display Message plugin page

@normal @POCConsent @label:allure_id:1655571 @tms:1655571 @story:POCConsent @parentSuite:POCConsent @owner:QA
Scenario: Verify POCConsent Plugin - (Basic test to check essential Consent flow)
	Given I launch the plugin app
	When I scroll 'Down' to and press 'POCConsent. POCConsentPlugin'
	Then Validate 'Your online privacy is our priority' text is displayed on Consent part1 page
	When I press 'ScrollToBottomPart1' on 'ConsentPart1Page'
	When I press 'AcceptAndContinuePart1Button' on 'ConsentPart1Page'
	Then Validate 'Personalized notifications' text is displayed on Consent part2 page
	When I press 'ScrollToBottomPart2' on 'ConsentPart2Page'
	When I press 'AcceptAndContinuePart2Button' on 'ConsentPart2Page'
	Then Validate 'Completed' text is displayed on the Display Message plugin page
	When I press Close button on Display Message plugin
	Then Validate 'Closed' text is displayed on the Display Message plugin page