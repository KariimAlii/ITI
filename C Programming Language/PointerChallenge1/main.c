#include <stdio.h>
#include <stdlib.h>

int main()
{
    int x = 7;
    int *ptr = NULL;

    // Variable's Information
    printf("The Variable's Value : %d\n",x);
    printf("The Variable's Address : %p\n\n",&x);

    // Linking Pointer to Variable
    ptr = &x;
    // Pointer's Information
    printf("The Pointer's Value: %p\n",ptr);
    printf("The Pointer's Address: %p\n",&ptr);
    printf("The Pointer Pointing to Value: %d\n",*ptr);
    printf("The Pointer Size: %d Bytes\n",sizeof(ptr));
    return 0;
}
