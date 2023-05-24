#include <stdio.h>
#include <stdlib.h>
struct Employee
{
    int id;
    char name[20];
    int salary;
};
struct Employee FillEmp(void);
void PrintEmp(struct Employee e);

int main()
{
    struct Employee e;
    e = FillEmp();
    PrintEmp(e);
    return 0;
}
struct Employee FillEmp(void)
{
    struct Employee e;
    printf("Insert The Employee Id : ");
    scanf("%d",&e.id);
    printf("Insert The Employee Name : ");
    scanf("%s",e.name);
    printf("Insert The Employee Salary : ");
    scanf("%d",&e.salary);
    return e;
};
void PrintEmp(struct Employee e)
{
    printf("Employee id: %d \n",e.id);
    printf("Employee Name: %s \n",e.name);
    printf("Employee Salary: %d \n",e.salary);
}
