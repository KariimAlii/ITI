#include <stdio.h>
#include <stdlib.h>

struct Node
{
    int Data;
    struct Node *pNext;
};
struct Node *A = NULL;
struct Node *B = NULL;
struct Node *S = NULL;
struct Node *CreateNode(int d)
{
    struct Node *ptr;
    ptr = (struct Node *)malloc(sizeof(struct Node));
    if (ptr)
    {
	ptr->Data = d;
	ptr->pNext = NULL;
    }
    return ptr;
}
struct Node *PushNode(struct Node *pHead, int d)
{
    struct Node *pNode;
    pNode = CreateNode(d);
    if (pHead == NULL)
    {
	pHead = pNode;
    }
    else
    {
	pNode->pNext = pHead;
	pHead = pNode;
    }
    return pHead;
}
void ListNodes(struct Node *pHead)
{
    struct Node *ptr;
    ptr = pHead;
    while (ptr)
    {
	printf("%d\n", ptr->Data);
	ptr = ptr->pNext;
    }
}
struct Node *Merge(struct Node *a, struct Node *b)
{
    struct Node *s, *Pa, *Pb,*pCur;
    Pa = a;
    Pb = b;
    if (Pa == NULL)
	return Pb;
    if (Pb == NULL)
	return Pa;
    if (Pa->Data < Pb->Data)
    {
	s = pCur = Pa;
	Pa = Pa->pNext;
    }
    else
    {
	s = pCur = Pb;
	Pb = Pb->pNext;
    }

    while (Pa != NULL && Pb != NULL)
    {
	if (Pa->Data < Pb->Data)
	{
	    pCur -> pNext = Pa;
	    pCur = pCur -> pNext;
	    Pa = Pa->pNext;
	}
	else
	{
	    pCur -> pNext = Pb;
	    pCur = pCur -> pNext;
	    Pb = Pb->pNext;
	}
    }
    if (Pa == NULL)
	pCur->pNext = Pb;
    else
	pCur->pNext = Pa;
    return s;
}
int main()
{

    A = PushNode(A, 6);
    A = PushNode(A, 5);
    A = PushNode(A, 4);
    printf("Items of List A : \n");
    ListNodes(A);
    B = PushNode(B, 3);
    B = PushNode(B, 2);
    B = PushNode(B, 1);
    printf("Items of List B : \n");
    ListNodes(B);
    S = Merge(A,B);
    printf("Items of List S : \n");
    ListNodes(S);

    return 0;
}
