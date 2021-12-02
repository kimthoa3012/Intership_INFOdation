using System;
using System.Collections.Generic;
using System.Linq;


namespace class_LinQ
{
    class SinhVien{
        public int ID {get; set;}
        public string Name {get; set;}
        public int Age { get; set; }
        public bool Sex {get; set;}
        public int MajorID {get; set;}

        public SinhVien(int id, string name, int age, bool sex, int majorID){
            ID=id;
            Name = name;
            Age = age;
            Sex = sex;
            MajorID = majorID;
        }

        public override string ToString()
        {
            return ID + " - " + Name + " - " + Age + " - " + Sex +" - " + MajorID;
        }
    }

    class Major{
        public int ID {get; set;}
        public string Name {get; set;}
        public int DepartmentID {get; set;}

        public Major(int id, string name, int departmentID){
            ID = id;
            Name = name;
            DepartmentID = departmentID;
        }
    }

    class Department{
        public int ID {get; set;}
        public string Name{get; set;}

        public Department(int id, string name){
            ID = id;
            Name = name;
        }
    }
    class Program
    {
        static void Main()
        {
            var departments = new List<Department>{
                new Department(1, "Công nghệ thông tin"),
                new Department(2, "Kinh tế")
            };

            var majors = new List<Major>(){
                new Major(1, "Công nghệ thông tin", 1),
                new Major(2, "Kinh doanh xuất nhập khẩu", 2),
                new Major(3, "Marketing", 3)
            };


            var sinhViens = new List<SinhVien>(){
                new SinhVien(1, "Nguyễn Văn A", 20, true, 1),
                new SinhVien(2, "Nguyễn Thị B", 23, false,2),
                new SinhVien(3, "Trần Văn c", 18, true,2)
            };

            //Lấy tên những sinh viên có tuổi từ 18 đến 22
            var query1 = (from sv in sinhViens
                        where sv.Age >= 18 && sv.Age <= 22
                        select sv);
            var query2 = sinhViens.Where(sv=>sv.Age>=18 && sv.Age<=22);
            
            //Sắp xếp
            var query3 = from sv in sinhViens
                        orderby sv.MajorID descending, sv.Age
                        select sv;
            
            var query4 = sinhViens.OrderByDescending(sv=>sv.MajorID).ThenByDescending(sv=>sv.Age);
            
            
            //Nhóm các sinh viên theo key là majorID
            var group1s = from sv in sinhViens
                        group sv by sv.MajorID;
            var group2s = sinhViens.GroupBy(sv=>sv.MajorID);
            foreach(var majorGroup in group2s){
                Console.WriteLine("Group: {0}", majorGroup.Key);
                foreach (var sv in majorGroup)
                {
                    Console.WriteLine(sv);
                }
            }

            //Join bảng sinhvien và major và department
            var joinResult1 = from sv in sinhViens // outer sequence
                      join m in majors //inner sequence 
                      on sv.MajorID equals m.ID
                      join d in departments
                      on m.DepartmentID equals d.ID // key selector 
                      select new { // result selector 
                                    Name = sv.Name,
                                    majorName = m.Name,
                                    departmentName = d.Name
                                };
            var joinResult2 = sinhViens.Join(// outer sequence 
                      majors,  // inner sequence 
                      sv => sv.MajorID,    // outerKeySelector
                      m => m.ID,  // innerKeySelector
                      (sv, m) => new  // result selector
                                    {
                                        Name = sv.Name,
                                        majorName = m.Name
                                    });

            foreach (var sv in joinResult1)
            {
                Console.WriteLine(sv);
            }

            //kiểm tra tất cả sinh viên đều là nữ hay ko
            var result1 = sinhViens.All(sv=>sv.Sex==false);
            Console.WriteLine(result1);

            var result2 = sinhViens.Any(sv=>sv.Sex==false);
            Console.WriteLine(result2);

            //List tên sinh viên
            //var listName = sinhViens.Aggregate((sv1, sv2) => sv1.Name + " ," + sv2.Name);

            //Trung bình tuổi
            var ageAvg = sinhViens.Average(sv=>sv.Age);
            Console.WriteLine("Age Average: {0}", ageAvg);

            //Cho biết số lượng sinh viên nam
            var totalSV = sinhViens.Count(sinhViens=>sinhViens.Sex==true);
            Console.WriteLine("Total male Sv: {0}", totalSV);

            //Đếm sinh viên chuyên ngành cntt
            var svCNTT = (sinhViens.Join(// outer sequence 
                      majors,  // inner sequence 
                      sv => sv.MajorID,    // outerKeySelector
                      m => m.ID,  // innerKeySelector
                      (sv, m) => new  // result selector
                                    {
                                        Name = sv.Name,
                                        majorName = m.Name
                                    })).Count(s=>s.majorName=="Công nghệ thông tin");
            Console.WriteLine("Total SV CNTT: {0}", svCNTT);

            

        }
    }
}