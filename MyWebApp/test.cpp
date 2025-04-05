#include<iostream>
using namespace std;

int main() 
{
	//temporary variable
	int employeeId = 0;
	string employeeName = "";
	string employeeDepartment = "";
	int employeeSalary = 0;
	int employeeAge = 0;
	string employeePoition = "";
	cout << "Enter Employee ID: ";
	cin >> employeeId;
	cout << "Enter Employee Name: ";
	cin >> employeeName;
	cin.ignore(); // to ignore the newline character left in the buffer
	cout << "Enter Employee Department: ";
	getline(cin, employeeDepartment);
	cout << "Enter Employee Salary: ";
	cin >> employeeSalary;
	cout << "Enter Employee Age: ";
	cin >> employeeAge;
	cout << "Enter Employee Position: ";
	cin >> employeePoition;
	cout << "Employee ID: " << employeeId << endl;
	cout << "Employee Name: " << employeeName << endl;

	cout << "Employee Department: " << employeeDepartment << endl;
	cout << "Employee Salary: " << employeeSalary << endl;
	cout << "Employee Age: " << employeeAge << endl;
	cout << "Employee Position: " << employeePoition << endl;
	cout << "Employee Details Entered Successfully!" << endl;
	
	return 0;
}
