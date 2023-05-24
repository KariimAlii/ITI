#include<stdio.h>
#include<conio.h>
#include<math.h>
int calculatePower(int base , int power);

int main()
{
int base , power , result;
printf("Enter the base number");
scanf("%d",&base);
printf("Enter the power number");
scanf("%d",&power);
result = calculatePower(base,power);
printf("The result of %d ** %d = %d",base,power,result);

getch();
clrscr();
return 0;
}

int calculatePower(int base , int power)
{
  if (power != 0) return (base * calculatePower(base,power-1));

  else return 1;


}