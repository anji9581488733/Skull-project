Feature: ReadPrivacyPolicy

    Scenario: provide option to reach privacy policy website
        Given I launch the plugin app
        When I scroll 'Down' to and press 'ReadPrivacyPolicy. ReadPrivacyPolicyPlugin'
        Then Validate header is displayed on the 'ReadPrivacyPolicyPlugin' page
        And Validate 'back' button is 'displayed' on the ReadPrivacyPolicyPlugin page
        And Validate 'close' button is 'notDisplayed' on the ReadPrivacyPolicyPlugin page
        And Validate 'PrivacyPolicyBody' is displayed on the ReadPrivacyPolicyPlugin page
        And Validate 'PrivacyPolicyLink' is displayed on the ReadPrivacyPolicyPlugin page
        
    Scenario: Verify the ReadPrivacyPolicy plugin is closed with Back button
        Given I launch the plugin app
        When I scroll 'Down' to and press 'ReadPrivacyPolicy. ReadPrivacyPolicyPlugin'
        When I press back button on the ReadPrivacyPolicyPlugin Page
        Then Validate header is displayed on the 'MenuPage' page