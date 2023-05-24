#include<stdio.h>
#include<conio.h>

int main()
{

int Count , i , Num , Max , Min;


printf("Enter How many Numbers you want ? \n");
scanf("%d",& Count);

i=1;
printf("Enter Number{%d}",i);
scanf("%d",&Num);
Max = Num;
Min = Num;


for(i=2;i<=Count;i++)
{
printf("Enter Number{%d}",i);
scanf("%d",&Num);
if (Num < Min) Min = Num;
if (Num > Max) Max = Num;

}

printf("The Max Number is : %d\n",Max);
printf("The Min Number is : %d\n",Min);

getch();
clrscr();
return 0;

}