Feature: Feature1
	As a user
	I want to search google
	So that I get relevant results 

@mytag
	Scenario: Search Google for the word 'Selenium'
	Given I Navigate to the Google Home Page
	When I Search for 'Selenium'
	Then the corresponding results are displayed

	Scenario: Open Craneware home page
	Given I navigate to craneware home page
	When I hit the Profile Update Page
	Then the Edit details page is displayed 
	And the contact number is available


