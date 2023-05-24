#include <stdio.h>
#include <stdlib.h>
struct Node
{
    int Data;
    struct Node *pNext;
};
struct Node *a = NULL;
struct Node *b = NULL;
struct Node *CreateNode(int d)
{
    struct Node *ptr;
    ptr = (struct Node *)malloc(sizeof(struct Node));
    if (ptr)
    {
        ptr->Data = d;
        ptr->pNext = NULL;
        printf("New Node Created with Data: %d\n", ptr->Data);
    }
    return ptr;
}
void PushNode(struct Node *pHead, int d)
{
    struct Node *pNode;
    pNode = CreateNode(d);
    if (pHead == NULL)
    {
        pHead = pNode;
        printf("The First Node Added with Data : %d\n",pHead -> Data);
    }
    else
    {
        pNode->pNext = pHead;
        pHead = pNode;
        printf("New Node Added with Data : %d\n",pHead -> Data);
    }

}
void ListNodes (struct Node* pHead) {
    struct Node* ptr;
    ptr = pHead;
    while (ptr) {
        printf("%d\n",ptr->Data);
        ptr = ptr -> pNext;
        printf("im here!");
    }
}
int main()
{
    PushNode(a,3);
    PushNode(a,4);
    PushNode(a,5);
    ListNodes(a);
    return 0;
}
