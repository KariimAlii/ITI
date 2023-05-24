#include<stdio.h>
#include<conio.h>
main()
{
/*
int numbers[5];


int i;
const int Count = 5;
int Num;
int Max , Min;
for (i = 0 ; i < Count ; i++)
{
printf("Enter  Number %d:",i);
scanf("%d",&Num);
numbers[i] = Num;
}

Max=numbers[0];
Min=numbers[0];
for (i=1 ; i < Count ; i++)
{
	if(numbers[i] > Max)
		Max = numbers[i];
	if(numbers[i] < Min)
		Min = numbers[i];

}


printf("The Max Number is: %d\n",Max);
printf("The Min Number is: %d",Min);
*/
int Num1,Num2,Num3,Num4,Num5;
int Max,Min;

printf("Enter First Number");
scanf("%d",&Num1);

printf("Enter Second Number");
scanf("%d",&Num2);

printf("Enter Third Number");
scanf("%d",&Num3);

printf("Enter Fourth Number");
scanf("%d",&Num4);

printf("Enter Fifth Number");
scanf("%d",&Num5);

Max = Num1;


if (Num2 > Max){ Max = Num2 ;}
else if (Num3 > Max){ Max = Num3; }
else if (Num4 > Max){ Max = Num4;}
else if (Num5 > Max){ Max = Num5;}
printf("The Max Number is : %d\n",Max);


getch();
clrscr();
return 0;

}