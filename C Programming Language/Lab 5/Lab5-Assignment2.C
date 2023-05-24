
#include <stdio.h>
#include <conio.h>



int main()
{

int ar[4][3];

int row,col,Sum,Avg;

for (row = 0; row < 4; row ++)
{
	for (col=0; col<3; col++)
		{
		printf("Enter the Grade for Student %d in Subject %d\n",row+1,col+1);
		scanf("%d",&ar[row][col]);
		}
}

Sum = 0;
for (row = 0 ;  row < 4; row++)
{
	for (col=0; col < 3; col++)
	{
		Sum = Sum + ar[row][col];
	}
	printf("The Sum of Grades For the Student(%d) is: %d\n",row+1,Sum);
	Sum=0;
}

Avg = 0;
Sum = 0;
for (col = 0 ;  col < 3; col++)
{
	for (row=0; row < 4; row++)
	{
		Sum = Sum + ar[row][col];
		Avg = Sum / 4;


	}
	Sum=0;
	printf("The Average Grade for Subject(%d) is %d\n",col+1,Avg);

}

/*
Avg = ar[0][0];
Sum = ar[0][0];
for (row=1; row < 4; row++)
{
Sum = Sum + ar[row][0];
}
Avg = Sum / 4;
printf("The Average Grade for the First Subject is: %d\n",Avg);
*/

getch();
clrscr();
return 0;
}