#include <stdio.h>
int main () 
{
	double a1=0,b1=0,c=1;
	long long int a2=0,b2=0,a1t;
	char zero = '1';
	scanf("%lf%lf",&a1,&b1);	
	for(;(long long int)a1<a1||(long long int)b1<b1;c=c*0.1)
	{
		a1=a1*10;
		b1=b1*10;
	}
	a2=(long long int)a1;
	b2=(long long int)b1;
	a1=0;
	while(a2>0||b2>0)
	{
		a1=a1+(double)((a2%10+b2%10)%7)*c;c=c*10;
		a2=(a2/10)+((a2%10+b2%10)/7);b2=(b2/10);	
	}
	printf("%lf",a1);
}
