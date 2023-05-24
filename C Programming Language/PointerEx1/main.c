#include <stdio.h>
#include <stdlib.h>

int main()
{
    int number = 0;
    int *pnumber = NULL;

    number = 10;
    // Variable's Information
    printf("Number's Address: %p\n",&number);
    printf("Number's Value: %d \n\n",number);

    // link variable to pointer
    pnumber = &number;

    // Pointer's Information

    printf("The pointer's Address: %p\n",(void*)&pnumber);
    printf("The pointer's Value: %p\n",pnumber);
    printf("The pointer's pointing to %d\n",*pnumber);

    printf("The pointer's Size is %d bytes",sizeof(pnumber));
    return 0;
}
