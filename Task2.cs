/*
 * Created by SharpDevelop.
 * User: nevermind
 * Date: 11.10.2016
 * Time: 7:11
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;

namespace Softheme
{
	/// <summary>
	/// Description of Task2.
	/// </summary>
	public class Task2
	{
		public const int dimension = 6;
		
		static int getInt(int[] m){
			String s = "";
			for (int i = 0; i < m.Length; i++){
				s += m[i];
			}
			return Int32.Parse(s);
		}
		
		static bool isPrime(int num){
			bool f = true;
			double d = (num/2) + 1;
			for(int i = 2; i < Math.Round(d); i++){
				if(num%i == 0){
					f = false;
				}
			}
			return f;
		}
		
		static bool isCircularPrime(int[] num, ArrayList arr){
			bool f = true;
			int[] m2 = new int[num.Length];
			Array.Copy(num, m2, num.Length);
	        for(int i = 0; i < num.Length; i++){
	            int number = getInt(m2);
	            if(!isPrime(number)){
	                f = false;
	            }
	            m2 = shift(m2);
	        }
	        if(f){
	            int t = getInt(num);
	            arr.Add(t);
	        }
	        return f;
		}
		
		static int[] shift(int[] m){
			int[] mm = new int[m.Length];
			mm[m.Length-1] = m[0];
	        for(int i = 1; i < m.Length; i++){
	            mm[i-1] = m[i];
	        }
        return mm;
		}
		
		static void reccure(int[] m, int step, ArrayList arr){
			int[] val = new int[] {1, 3, 7, 9 };
			for(int i = 0; i < val.Length; i++){
				m[step] = val[i];
				if(step == (m.Length-1)){
					isCircularPrime(m, arr);
				}else{
					reccure(m, (step + 1), arr);
				}
			}
		}
		
		static void generation(ArrayList arr){
			for(int i = 2; i < 9; i++){
				if(isPrime(i)){
					arr.Add(i);
				}
			}
			for(int i = 2; i <= dimension; i++){
				int[] m = new int[i];
				reccure(m, 0, arr);
			}
			Console.WriteLine("with dimension = " + dimension + ", we have " + arr.Count + " Circular Prime numbers");
		}
       
		public Task2()
		{
			ArrayList arr = new ArrayList();
        	generation(arr);
		}
	}
}
