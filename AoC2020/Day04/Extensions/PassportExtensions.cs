using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day04.Extensions
{
    public static class PassportExtensions
    {
        public static int ValidPassportPart01(this string passportTxt)
        {
            return passportTxt.Split(new []{$"{Environment.NewLine}{Environment.NewLine}"}, StringSplitOptions.RemoveEmptyEntries).AsParallel() .ToList().Where(passportPart => { var fields = passportPart.Split(new []{" " , Environment.NewLine},  StringSplitOptions.RemoveEmptyEntries) .Select(x => x.Split(':')[0]).ToHashSet(); return  fields.Count == 8 || fields.Count == 7 && !fields.Contains("cid"); }).Count();
        }
        
        public static int ValidPassportPart02(this string passportTxt)
        {
            return passportTxt.Split(new []{$"{Environment.NewLine}{Environment.NewLine}"},  StringSplitOptions.RemoveEmptyEntries).AsParallel() .ToList().Where(passportPart => { var vals = passportPart.Split(new []{" " , Environment.NewLine},  StringSplitOptions.RemoveEmptyEntries) .Select(x => x.Split(':')).ToDictionary(x => x[0], x => x[1]); return (vals.Keys.Count == 8 || vals.Keys.Count == 7 && !vals.ContainsKey("cid")) && ushort.Parse(vals["byr"]) >= 1920 && ushort.Parse(vals["byr"]) <= 2002 && ushort.Parse(vals["iyr"]) >= 2010 && ushort.Parse(vals["iyr"]) <= 2020 && ushort.Parse(vals["eyr"]) >= 2020 && ushort.Parse(vals["eyr"]) <= 2030 && (vals["hgt"].EndsWith("cm") && uint.Parse(vals["hgt"].Replace("cm", string.Empty)) >= 150 && uint.Parse(vals["hgt"].Replace("cm", string.Empty)) <= 193 || vals["hgt"].EndsWith("in") && uint.Parse(vals["hgt"].Replace("in", string.Empty)) >= 59 && uint.Parse(vals["hgt"].Replace("in", string.Empty)) <= 76) && new Regex(@"^\#[0-9a-f]{6}$").IsMatch(vals["hcl"]) && new Regex(@"amb|blu|brn|gry|grn|hzl|oth").IsMatch(vals["ecl"]) && (new Regex(@"^\d{9}$").IsMatch(vals["pid"]) && uint.Parse(vals["pid"]) != 0); }).Count();
        }
    }
}