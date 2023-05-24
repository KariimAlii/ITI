#include<stdio.h>
#include<conio.h>
#include<math.h>
int main()
{

int a,b,c ;
int x1,x2;

printf("Enter coeff of x*2\n");
scanf("%d",& a );

printf("Enter coeff of x\n");
scanf("%d",& b );

printf("Enter constant c\n");
scanf("%d",& c);

if ( (b*b - 4 * a * c) > 0 )
{

x1 = ( -b + sqrt(b*b - 4*a*c) ) / (2*a);
x2 = ( -b - sqrt(b*b - 4*a*c) ) / (2*a);
printf("Your two roots are : %d & %d",x1,x2);

}

else {
printf("These coefficients give unreal roots!");
}

       // a = 1 , b=5 , c = 6  ==> x1 = -2 , x2 = -3

 getch();
 clrscr();
 return 0;
}