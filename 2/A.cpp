#include<iostream>
#include <stdarg.h>
using namespace std;
int main(void) 
{
	int*A=new int[1]();
	int*B=new int[1]();
	char S='A';
	int Minover60=101,Maxlower60=-1;
	//Maxlower60低於60(不含)的最大值
	//Minover60高於60(含)的最小值 
	int X=0,C=0,i=0,p=0;
	cin >> X;X=0;
	while(cin>>X)
	{
		if(cin.fail())break;
		if(S=='A')
		{
			//cout << "C=" << C << endl;
			A[C]=X;
			delete [] B;
			B=new int[C+2]();
			for(i=0;i<=C;i++)
				B[i]=A[i];
			C++;
			S='B';
		}
		else if(S=='B')
		{
			//cout << "C=" << C << endl;
			B[C]=X;
			delete [] A;
			A=new int[C+2]();
			for(i=0;i<=C;i++)
			A[i]=B[i];
			C++;
			S='A';
		}
	}
	//cout << "C=" << C << endl;
	if(S=='A')
	{
		cout << "SA" << endl;
		for(i=0;i<C;i++)
		{
			if(B[i]<60&&B[i]>=Maxlower60)
			Maxlower60=B[i];
			if(B[i]>=60&&B[i]<=Minover60)
			Minover60=B[i];
		}
		i=0;
		for(X=0;X==0;i++)//排序 B
		{
			if(i>=(C-1))
			{
				i=0;
				X=1;
			}
			if(B[i]>B[i+1])
			{
				cout << "B" << endl;
				X=0;
				p=0;
				p=B[i];
				B[i]=B[i+1];
				B[i+1]=p;	
			}
			
		}
		for(i=0;i<(C-1);i++)
			cout << B[i] << " ";
		cout << B[i] << endl;
	
	}
	else if(S=='B')
	{
		cout << "SB" << endl;
		for(i=0;i<C;i++)
		{
			if(A[i]<60&&A[i]>=Maxlower60)
			Maxlower60=A[i];
			if(A[i]>=60&&A[i]<=Minover60)
			Minover60=A[i];
		}
		i=0;
		for(X=0;X==0;i++)//排序 A
		{
			if(i>=(C-1))
			{
				i=0;
				X=1;
			} 
			if(A[i]>A[i+1])
			{
				X=0;
				p=0;
				p=A[i];
				A[i]=A[i+1];
				A[i+1]=p;	
			}
		}
		for(i=0;i<(C-1);i++) 
			cout << A[i] << " ";
		cout << A[i] << endl;
	} 
	if(Minover60!=101)
		cout << Minover60 << endl;
	else
		cout << "worst case" << endl; 
	if(Maxlower60!=-1)
		cout << Maxlower60 << endl;
	else
		cout <<"best case" << endl;
	delete [] A;
	delete [] B;
	return 0;
}
