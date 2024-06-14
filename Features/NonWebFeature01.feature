
Feature: Non Web Tests

Scenario: Test1 Json Data
   When the following JSON data:
        """
		{
		   "Name": "Rajeev Singh",
		   "Age": 30
		}
		"""
   When the following JSON data2:
        """
		{
		   "Name": "Auto Singh",
		   "Dept": "QA"
		}
		"""

Scenario: Test2 Test Step error Data
   When the following JSON data2:
        """
		{
		   "Name": "Auto Singh",
		   "Dept": "QA"
		}
		"""
	Then should be error in step