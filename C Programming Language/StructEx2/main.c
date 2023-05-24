#include <stdio.h>
#include <stdlib.h>

struct Date
{
    int day;
    int month;
    int year;
    char name[30];
};
int main()
{
    int i;
    struct Date family[10] = { {20,10,1996,{"Karim Ali Ramadan"}} , {3,9,2000,{"Marawan Ali Ramadan"}} , {25,11,1972,{"Samia Mohamed Attiya"}} };
    for (i=0;i<=2;i++)
    {
        printf("Name : %s\n",family[i].name);
        printf("Birth Date : %d/%d/%d\n" , family[i].day , family[i].month , family[i].year%100 );
    }
    return 0;
}
