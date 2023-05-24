#include <stdio.h>
#include <conio.h>

int main()
{
int ar[5] = {6,2,8,4,7};
int i, max , min;

min = ar[0];
max = ar[0];


for (i = 1 ; i< 5 ; i++)
{

  if (ar[i] > max) max = ar[i];
  if (ar[i] < min) min = ar[i];

}
printf("For Array Numbers:\n");
for (i = 0 ; i< 5 ; i++)
{

  printf("%d , ",ar[i]);

}
printf("\nThe max Number is: %d\n",max);
printf("The min Number is: %d\n",min);
getch();
clrscr();
return 0;

}