#include <stdio.h>
#include <stdlib.h>
// Count Odd Numbers in a Linkedlist
//==================================================
struct Node {
    int Data;
    struct Node* pNext;
};
struct Node* pHead;
int Count;
int main()
{
    printf("Hello world!\n");
    return 0;
}
int CountOddNumbers (struct Node* pHead) {
    int Count = 0;
    struct Node* ptr;
    if (pHead) {
        ptr = pHead;
        while (ptr != NULL) {
            if (ptr -> Data % 2 != 0) Count++;
            ptr = ptr -> pNext;
        }
    }
    return Count;
}
