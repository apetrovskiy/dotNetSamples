Feature: BackgroundWithExamples
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

Background: 
	Given I have entered 10 into the calculator

@mytag
Scenario Outline: Add two numbers
	Given I have entered <input 2> into the calculator
	And I have entered <input 3> into the calculator
	When I press add
	Then the result should be <result> on the screen

	Examples: regression
	| description | input 1 | input 2 | input 3 | result |
	| sample 01   | 10      | 50      | 70      | 130    |