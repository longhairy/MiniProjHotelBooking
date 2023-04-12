Feature: CreateBooking


@mytag
Scenario Outline: createbokking
	Given the start date is <startDate>
	And the end date is <endDate>
	When the booking created
	Then the result shold be true


	Examples: 
	| startDate  | endDate    | result |
	| 2023-04-13 | 2023-04-14 | True   |