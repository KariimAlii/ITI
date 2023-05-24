#include <stdio.h>
#include <stdlib.h>
struct date
{
    int day;
    int month;
    int year;
};
int main()
{
    struct date today;  // variable of datatype  (struct date)
    struct date* ptr; // pointer to structure

    ptr = &today;

    ptr->day = 20;
    ptr->month = 10;
    ptr->year = 1996;

    printf("Your BirthDate is %d/%d/%d" , ptr->day , ptr->month , ptr->year );
    return 0;
}
