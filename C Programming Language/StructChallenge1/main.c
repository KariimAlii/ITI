#include <stdio.h>
#include <stdlib.h>
#include <conio.h>
struct Employee
{
    char name[20];
    struct Date
    {
        int day;
        int month;
        int year;
    }hireDate;
    float salary;
};
int main()
{
    struct Employee employees[5] = {{.name="Karim Ali",.hireDate={20,10,1996},.salary=7800.56f}};
    getch();
    printf("Name: %s \n",employees[0].name);
    printf("Hire Date: %d/%d/%d \n",employees[0].hireDate.day,employees[0].hireDate.month,employees[0].hireDate.year);
    printf("Salary : %.2f EGP \n",employees[0].salary);

    printf("Enter the second employee information \n");

    printf("Name: ");
    scanf("%s",employees[1].name);

    printf("Date: \n");
    printf("Day: ");
    scanf("%d",&employees[1].hireDate.day);
    printf("Month: ");
    scanf("%d",&employees[1].hireDate.month);
    printf("Year: ");
    scanf("%d",&employees[1].hireDate.year);

    printf("\nSalary: ");
    scanf("%f",&employees[1].salary);

    printf("Name: %s \n",employees[1].name);
    printf("Hire Date: %d/%d/%d \n",employees[1].hireDate.day,employees[1].hireDate.month,employees[1].hireDate.year);
    printf("Salary : %.2f EGP \n",employees[1].salary);

    return 0;
}
