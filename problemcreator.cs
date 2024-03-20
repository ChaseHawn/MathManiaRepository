using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class problemcreator : Node
{
	// Called when the node enters the scene tree for the first time.
	static Dictionary<string,string> Deriv(int diff)
		{
		Dictionary<string, string> mathpd = new Dictionary<string, string>();
		List<List<int>> coefficients = new List<List<int>>();
		List<int> rawco = new List<int>();
		List<string> opco = new List<string>();
		List<string> keyList = new List<string>(mathpd.Keys);
		string problem = "What is the derivative of ";
		string answer = "0";
		Random rnd = new Random();
		int check = 0;
		int upper = 0;
		int lower = 0;
		if (diff == 0) //determining difficulty of coefficients of derivative (like range, its 1 more or less than how much the range is)
		{
			upper = 4;
			lower = -1;
		}
		else if (diff == 1)
		{
			upper = 6;
			lower = -1;
		}
		else if (diff == 2)
		{
			upper = 4;
			lower = -4;
		}
		else if (diff == 3)
		{
			upper = 6;
			lower = -6;
		}
		else if (diff == 4)
		{
			upper = 21; 
			lower = -21;
		}
		for (int j = 0; j < 1000; j++)
		{
			rawco.Clear();
			for (int p = 0; p < rnd.Next(1, 4); p++)
			{
				rawco.Add(rnd.Next(lower, upper));
			}
			coefficients.Add(rawco.ToList());
		}
		for (int j = 0; j < coefficients.Count; j++)
		{
			if (coefficients[j].Count == 1)
			{
				check = 0;
				foreach (string item in keyList)
				{
					if (item.Contains("What is the derivative of " + coefficients[j][0].ToString()))
					{
						check = 1;
					}
				}
				if (check == 0)
				{
					mathpd.Add("What is the derivative of " + coefficients[j][0].ToString(), "0"); // dictionary of answer and solution
				}
			}
			else if (coefficients[j].Count == 2)
			{
				opco.Clear();
				problem = "What is the derivative of ";
				answer = "0";
				for (int p = 0; p < 2; p++)
				{
					if (coefficients[j][p] < 0)
					{
						opco.Add(" - " + Math.Abs(coefficients[j][p]).ToString());
					}
					else if (coefficients[j][p] > 0)
					{
						opco.Add(" + " + Math.Abs(coefficients[j][p]).ToString());
					}
					else if (coefficients[j][p] == 0)
					{
						opco.Add("NULL");
					}
				}
				if (opco[0] != "NULL")
				{
					problem = problem + opco[0] + "x";
					answer = "";
					answer = answer + coefficients[j][0].ToString();
				}
				if (opco[1] != "NULL")
				{
					problem = problem + opco[1];
				}

				check = 0;
				foreach (string item in keyList)
				{
					if (item.Contains(problem))
					{
						check = 1;
					}
				}
				if (check == 0)
				{
					mathpd.Add(problem, answer);
				}
			}
			else if (coefficients[j].Count == 3)
			{
				opco.Clear();
				problem = "What is the derivative of ";
				answer = "0";
				for (int p = 0; p < 3; p++)
				{
					if (coefficients[j][p] < 0)
					{
						opco.Add(" - " + Math.Abs(coefficients[j][p]).ToString());
					}
					else if (coefficients[j][p] > 0)
					{
						opco.Add(" + " + Math.Abs(coefficients[j][p]).ToString());
					}
					else if (coefficients[j][p] == 0)
					{
						opco.Add("NULL");
					}
				}
				if (opco[0] != "NULL" || opco[1] != "NULL")
				{
					answer = "";
				}
				if (opco[0] != "NULL")
				{
					problem = problem + opco[0] + "x^2";
					answer = answer + (2 * coefficients[j][0]).ToString() + "x";
				}
				if (opco[1] != "NULL")
				{
					problem = problem + opco[1] + "x";
					if (coefficients[j][1] > 0)
					{
						answer = answer + "+" + coefficients[j][1].ToString();
					}
					else
					{
						answer = answer + coefficients[j][1].ToString();

					}
				}
				if (opco[2] != "NULL")
				{
					problem = problem + opco[2];
				}
				check = 0;
				foreach (string item in keyList)
				{
					if (item.Contains(problem))
					{
						check = 1;
					}
				}
				if (check == 0)
				{
					mathpd.Add(problem, answer);
				}
			}
			else if (coefficients[j].Count == 4)
			{
				opco.Clear();
				problem = "What is the derivative of ";
				answer = "0";
				for (int p = 0; p < 4; p++)
				{
					if (coefficients[j][p] < 0)
					{
						opco.Add(" - " + Math.Abs(coefficients[j][p]).ToString());
					}
					else if (coefficients[j][p] > 0)
					{
						opco.Add(" + " + Math.Abs(coefficients[j][p]).ToString());
					}
					else if (coefficients[j][p] == 0)
					{
						opco.Add("NULL");
					}
				}
				if (opco[0] != "NULL" || opco[1] != "NULL" || opco[2] != "NULL")
				{
					answer = "";
				}
				if (opco[0] != "NULL")
				{
					problem = problem + opco[0] + "x^3";
					answer = answer + (3 * coefficients[j][0]).ToString() + "x^2";
				}
				if (opco[1] != "NULL")
				{
					problem = problem + opco[1] + "x^2";
					if (coefficients[j][1] > 0)
					{
						answer = answer + "+" + (2 * coefficients[j][1]).ToString() + "x";
					}
					else
					{
						answer = answer + (2 * coefficients[j][1]).ToString() + "x";

					}
				}
				if (opco[2] != "NULL")
				{
					problem = problem + opco[2];
					if (coefficients[j][2] > 0)
					{
						answer = answer + "+" + coefficients[j][2].ToString() + "x";
					}
					else
					{
						answer = answer + coefficients[j][2].ToString() + "x";

					}
				}
				if (opco[3] != "NULL")
				{
					problem = problem + opco[3];
				}
				foreach (string item in keyList)
				{
					if (item.Contains(problem))
					{
						check = 1;
					}
				}
				check = 0;
				foreach (string item in keyList)
				{
					if (item.Contains(problem))
					{
						check = 1;
					}
				}
				if (check == 0)
				{
					mathpd.Add(problem, answer);
				}
			}
			keyList.Clear();
			foreach (string key in mathpd.Keys)
			{
				keyList.Add(key);
			}
		}
		foreach (string key in mathpd.Keys)
		{
			keyList.Add(key);
		}
		return mathpd;
		}
	public override void _Ready()
	{
		Random rnd = new Random();
		List<string> keylist = new List<string>();
		Dictionary<string, string> mathp = new Dictionary<string, string>();
		Dictionary<string, string> mathpd = new Dictionary<string, string>();
		string useranswer = "";
		int difficulty = 4;
		mathpd = Deriv(difficulty);
		foreach(var problem in mathpd)
		{
			mathp.Add(problem.Key, problem.Value);
		}
		foreach (string key in mathpd.Keys)
		{
			keylist.Add(key);
		}
		string randomq = keylist[rnd.Next(-1, keylist.Count)];

		Console.WriteLine(randomq);
		useranswer = Console.ReadLine();
		useranswer = String.Concat(useranswer.Where(c => !Char.IsWhiteSpace(c)));
		Console.WriteLine(useranswer);
		Console.WriteLine(mathp[randomq]);
			

		}
	}

