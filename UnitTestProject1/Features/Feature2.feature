Feature: Feature2
	As a user
	I want to search google
	So that I get relevant results 

@mytag

	Scenario: Search Google for the word 'Specflow'
	Given I am in the Google Home Page
	When I Search for the 'Specflow' text
	Then the results are displayed

