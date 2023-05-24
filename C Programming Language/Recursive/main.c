#include <stdio.h>
#include <stdlib.h>
int Factorial (int x);
int Power (int base , int p);
int main()
{
    //================= Recursive Function =================//
    //================= Factorial Function =================//
    int num;
    printf("Enter Number");
    scanf("%d",&num);
    printf("Factorial of number %d = %d",num,Factorial(num));


    //================= Power Function =================//
    int num , pow;
    printf("Enter Number");
    scanf("%d",&num);
    printf("Enter Power");
    scanf("%d",&pow);
    printf("%d ** %d = %d" , num , pow , Power(num,pow) );
    return 0;
}
int Factorial (int x) {
    if (x == 1) return 1;
    else return x * Factorial(x-1);
}
int Power (int base , int p) {
    if (p == 0) return 0;
    else return base * Power(p-1);
}
