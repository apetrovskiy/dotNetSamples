Feature: Division
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the division of two numbers

@mytag
Scenario Outline: Divide two numbers
	Given I have entered <operandOne> as a first operand
	When I have divided the first operand by <operandTwo>
	Then the float result should be <result > on the screen

	Examples: integer and long
	| description | operandOne  | operandTwo  | result      |
	| default     | 100         | 50          | 2.0         |
	| big         | 10000000000 | 10000000000 | 1.0         |
	| negative    | -50         | -50         | 1.0         |
	| fail        | -50         | 0           | 1.0         |
