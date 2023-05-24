#include <stdio.h>
#include <stdlib.h>
struct Date
{
    int day;
    int month;
    int year;
};
struct Time
{
    int hour;
    int minute;
    int second;
};
struct DateAndTime
{
    struct Date sdate;
    struct Time stime;
};
struct Students
{
    struct PersonalInformation
    {
        char name[20];
        int age;
        char gender[10];
    }info;
    struct DateAndTime Data;
    int graduationYear;
    int Friends[10];
};
int main()
{
    int i;
    struct DateAndTime event = { {20,10,1996} , {.second=25,.hour=11,.minute=45} };
    printf("Your BirthDay Date is %d/%d/%d ",event.sdate.day,event.sdate.month,event.sdate.year % 100);
    printf( "at %d:%d:%d \n" , event.stime.hour , event.stime.minute , event.stime.second );

    struct Students karim = {
    {"Karim",26,"Male"},
    { {25,11,1972},{11,45,25} },
    2020,
    {1,2,3,4,5}
    };

    printf("Your Name is %s and you are %d years old and you are a %s\n" , karim.info.name , karim.info.age , karim.info.gender );
    printf("you were born on %d/%d/%d at %d:%d:%d\n" , karim.Data.sdate.day , karim.Data.sdate.month , karim.Data.sdate.year , karim.Data.stime.hour , karim.Data.stime.minute , karim.Data.stime.second );
    printf("You are graduated in %d\n",karim.graduationYear);
    printf("You have friends with id:\t");
    for (i=0;i<5;i++) printf("%d,",karim.Friends[i]);
    return 0;
}
