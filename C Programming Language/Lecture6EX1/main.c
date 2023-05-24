#include <stdio.h>
#include <stdlib.h>
void Swap(int* a , int* b);
int main()
{
    int x = 3 , y = 4;
    Swap(&x , &y);
    printf("X is %d , Y is %d" , x ,y);
    return 0;
}
void Swap(int* a , int* b)
{
    int temp;
    temp = *a;
    *a = *b;
    *b = temp;
}
