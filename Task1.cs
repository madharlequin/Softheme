/*
 * Created by SharpDevelop.
 * User: nevermind
 * Date: 11.10.2016
 * Time: 7:11
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Softheme
{
	/// <summary>
	/// Description of Task1.
	/// </summary>
	public class Task1
	{
		
		const int num = 100;
		
			static int getInt(string m){
				String s = "";
				for (int i = 0; i < m.Length; i++){
					s += m[i];
				}
				return Int32.Parse(s);
			}
			
			static void fillM(int[][] m){
				StreamReader sr = File.OpenText("file2.txt");
				for(int i = 0; i < num; i++){
					string s = sr.ReadLine();
					m[i] = new int[i+1];
					for(int j = 0; j < s.Length; j += 3){
						m[i][j/3] = getInt(s.Substring(j, 2));
					}
				}
                sr.Close();
			}
			
			static int calculate(int[][] m){
				for(int i = (num-2); i >= 0; i--){
					for(int j = 0; j <= i; j++){
						if((m[i][j]+m[i+1][j]) > (m[i][j]+m[i+1][j+1])){
							m[i][j] = m[i][j]+m[i+1][j];
						}else{
							m[i][j] = m[i][j]+m[i+1][j+1];
						}
					}
				}
				return m[0][0];
			}
			
		
		public Task1()
		{
			int[][] m = new int[num][];
			fillM(m);
			Console.WriteLine("max summ with " + num + " lines : " + calculate(m));
		}
	}
}
