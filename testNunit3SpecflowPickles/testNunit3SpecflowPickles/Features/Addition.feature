Feature: Addition
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario Outline: Add two numbers
	Given I have entered <operandOne> as a first operand
	When I have added <operandTwo> to the first operand
	Then the long result should be <result > on the screen

	Examples: integer and long
	| description | operandOne  | operandTwo  | result      |
	| default     | 50          | 70          | 120         |
	| big         | 10000000000 | 10000000000 | 20000000000 |
	| negative    | -50         | -70         | -120        |
	| wrong       | 50          | 70          | 150         |