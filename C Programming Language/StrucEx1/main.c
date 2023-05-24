#include <stdio.h>
#include <stdlib.h>

struct Date
{
    int month;
    int day;
    int year;
};
int main()
{
    /*
    struct Date
    {
        int month;
        int day;
        int year;
    }today;
    */
    struct Date today ;
    today.month = 10;
    today.day = 20;
    today.year = 1996;
    printf("Today's Date : Month/Day/Year = %d/%d/%d \n", today.month , today.day , today.year%100 );
    printf("Size of today = %d Byte",sizeof(today));
    return 0;
}

