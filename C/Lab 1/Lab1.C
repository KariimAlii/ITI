#include <stdio.h>
#include <conio.h>

int main()
{

int a;
int b;
int sum;

printf("Enter Your First Number....");
scanf("%d",& a );

printf("Enter Your Second Number....");
scanf("%d",& b );

sum = a + b;

printf("Your Sum = %d",sum);

getch();
clrscr();

return 0;
}