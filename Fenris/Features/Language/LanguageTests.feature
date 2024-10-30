Feature: LanguageTests
Verify TestSinglePlugin using different languages


@Language @label:allure_id:432414
Scenario Outline: Verify Consent Plugin in different languages
	Given I launch the plugin app in '<language>' and '<region>'
	When I scroll 'Down' to and press 'POCConsent. POCConsentPlugin'
	Then Validate 'Your online privacy is our priority' text is displayed on Consent part1 page
	Then Take a screenshot for the language test with '<language>' and '<region>'
	When I press 'ScrollToBottomPart1' on 'ConsentPart1Page'
	When I press 'AcceptAndContinuePart1Button' on 'ConsentPart1Page'
	Then Validate 'Personalized notifications' text is displayed on Consent part2 page
	When I press 'ScrollToBottomPart2' on 'ConsentPart2Page'
	When I press 'AcceptAndContinuePart2Button' on 'ConsentPart2Page'
	Then Validate 'Completed' text is displayed on the Display Message plugin page
	When I press Close button on Display Message plugin
	Then Validate 'Closed' text is displayed on the Display Message plugin page

	Examples:
    | language | region   |
    | en       | US       |
    | pl       | PL       |
    | da       | DK       |