#include <stdio.h>
#include <stdlib.h>
struct Employee
{
    int id;
    char name[20];
    int salary;
};
struct Employee FillEmp(void);
void PrintEmp(struct Employee* ptr, int i);

int main()
{
    int i;
    struct Employee* pEmp;
    struct Employee emp[4];

    pEmp = emp;

    for(i=0;i<4;i++) *(pEmp+i) = FillEmp();
    for(i=0;i<4;i++) PrintEmp(pEmp,i);

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
void PrintEmp(struct Employee* ptr, int i)
{
    printf("Employee id: %d \n",(ptr+i)->id);
    printf("Employee Name: %s \n",(ptr+i)->name);
    printf("Employee Salary: %d \n",(ptr+i)->salary);
}
