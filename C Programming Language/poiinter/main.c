#include <stdio.h>
#include <stdlib.h>
void Swap (int a , int b)
{
    int temp = a;
    a = b;
    b = temp;
}
int main()
{
    int x = 3 , y = 5;
    Swap(&x,&y);
    printf("X is %d , Y is %d",x,y);
    return 0;
}
