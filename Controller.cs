using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Collections;
using Ophthalmic_Clinic;
using System.Security.Cryptography;

namespace DBapplication
{
    public class Controller
    {
        DBManager dbMan;
        public Controller()
        {
            dbMan = new DBManager();
        }


        public void TerminateConnection()
        {
            dbMan.CloseConnection();
        }

        /////////NOTE:ALL COMMENTED QUERIES ARE DONE SO THAT IF A STORED PROCEDURE DIDN'T WORK/////////


        ////////////USEERS LOG IN/Register INFOS//////////////
        public DataTable LogIn(string user, string password)
        {
            String StoredProcedureName = StoredProcedures.Signin;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@user", user);
            Parameters.Add("@Pass", password);

            return dbMan.ExecuteReader1(StoredProcedureName, Parameters);
        }
        public DataTable LogIn2(string username, string password)
        {
            string role2 = "Medical Receptionist";
            string query = " select 'Receptionist' as UserType, ID,Password from Employee " +
                " where ID = '" + username + "' and Password = '" + password + "' and Emp_Role= '" + role2 + "' ";
            return dbMan.ExecuteReader(query);
        }

        public int RegisterPatient(string username, string password, string fname, string lname, int age, string gender)
        {
            string query = "INSERT INTO Patient Values ('" + username + "','" + fname + "','" + lname + "','" + gender + "'," + age + ",'" + password + "');";
            return dbMan.ExecuteNonQuery(query);
        }

        /////////////////PATIENTS FUNCTIONALITIES///////////////
        ///
        //public DataTable Healthrecords(string patientid)
        //{
        //    string query = "select * from Medical_Records where PatientID ='" + patientid + "';";
        //    return dbMan.ExecuteReader(query);
        //}

        public DataTable Healthrecords(string pid)
        {
            String StoredProcedureName = StoredProcedures.Getbills;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@pid", pid);
            return dbMan.ExecuteReader1(StoredProcedureName, Parameters);
        }

        public int FeedBacks(string id, string feedback)
        {
            string query = "insert into Feedback values ( '" + id + "', '" + feedback + "');";
            return dbMan.ExecuteNonQuery(query);
        }

        public int UpdatePersInfo(string id, string password)
        {
            string query = "update Patient set  " +
                "Password = '" + password + "' where ID = '" + id + "';";
            return dbMan.ExecuteNonQuery(query);
        }

        public DataTable review_services_off()
        {
            string query = "select * from Services;";
            return dbMan.ExecuteReader(query);
        }

        public DataTable GetRequestedAppointmenst(string id)
        {
            string query = "Select * from Request_Appointment ;";
            return dbMan.ExecuteReader(query);
        }

        ////////////Doctors Functionalities//////////////
        public int InsertMedicalRecord(int medicalid, int left, int right, string ast, string type, string catarct, string doctorid, string patientid)
        {
            string query = "INSERT INTO Medical_Records (MedicalID,LeftEye,RightEye,Astigmatism,Test_Type,Catarct_Test,DoctorID,PatientID)" +
                                     "Values (" + medicalid + ", " + left + ", " + right + ",'" + ast + "','" + type + "','" + catarct + "','" + doctorid + "','" + patientid + "');";
            return dbMan.ExecuteNonQuery(query);

        }
        public int UpdateslotOne(int value, string id)
        {
            string query = "Update DoctorTimeSlots SET slot1 = " + value + "  where doctorID ='" + id + "';";
            return dbMan.ExecuteNonQuery(query);
        }
        public int UpdateslotTwo(int value, string id)
        {
            string query = "Update DoctorTimeSlots SET slot2 = " + value + "  where doctorID ='" + id + "';";
            return dbMan.ExecuteNonQuery(query);
        }
        public int UpdateslotThree(int value, string id)
        {
            string query = "Update DoctorTimeSlots SET slot3 = " + value + "  where doctorID ='" + id + "';";
            return dbMan.ExecuteNonQuery(query);
        }
        public int UpdateslotFour(int value, string id)
        {
            string query = "Update DoctorTimeSlots SET slot4 = " + value + "  where doctorID ='" + id + "';";
            return dbMan.ExecuteNonQuery(query);
        }
        public int UpdateslotFive(int value, string id)
        {
            string query = "Update DoctorTimeSlots SET slot5 = " + value + "  where doctorID ='" + id + "';";
            return dbMan.ExecuteNonQuery(query);
        }
        public int UpdateslotSix(int value, string id)
        {
            string query = "Update DoctorTimeSlots SET slot6 = " + value + "  where doctorID ='" + id + "';";
            return dbMan.ExecuteNonQuery(query);

        }

        public int ChangeDoctorPassword(string pass, string id)
        {
            string query = "Update Doctor SET Password = '" + pass + "' " + " WHERE ID ='" + id + "';";
            return dbMan.ExecuteNonQuery(query);
        }

        public int AddDoctor(string ID, string Fname, string Lname, int salary, string dep, string pass)
        {
            string query = "INSERT INTO Doctor (ID,Fname,Lname,Salary,WorksIN_Dep,Password)" +
            "Values ('" + ID + "','" + Fname + "','" + Lname + "'," + salary + ",'" + dep + "','" + pass + "');";
            return dbMan.ExecuteNonQuery(query);
        }

        public int DeleteDoctor(string id)
        {
            string query = "DELETE FROM Doctor WHERE ID='" + id + "';";

            return dbMan.ExecuteNonQuery(query);
        }

        public DataTable CheackDepartHead(string id)
        {
            string query = "Select Department_Head_ID from Departments where Department_Head_ID = '" + id + "' ;";
            return dbMan.ExecuteReader(query);
        }

        ////////////Department head Functionalities//////////////
        public DataTable GetTechPhone(string serialn)
        {
            string query = "SELECT * FROM Tech_Equip_Serial WHERE Equip_serial='" + serialn + "'";
            return dbMan.ExecuteReader(query);
        }

        public int InsertEmployee(string id, string fname, string lname, int salary, string role, string depid, string superid, string pass)
        {
            string query = "INSERT INTO Employee (ID,Fname,Lname,Salary,Emp_Role,WorksIN_Dep,Supervisor,Password)" +
                            "Values ('" + id + "','" + fname + "','" + lname + "'," + salary + ",'" + role + "','" + depid + "','" + superid + "','" + pass + "');";
            return dbMan.ExecuteNonQuery(query);
        }
        public int UpdateEmployee(string id, string fname, string lname, int salary, string role, string depid, string pass)
        {
            string getSID = "SELECT Department_Head_ID FROM Departments WHERE DepartmentID='" + id + "';";
            string superid = dbMan.ExecuteReader(getSID).ToString();

            string query = "Update Employee SET Fname ='" + fname + "',Lname= '" + lname + "',Salary= " + salary + ",Emp_Role= '" + role + "',WorksIN_Dep= '" + depid + "',Supervisor= '" + superid + "',Password= '" + pass + "'  where ID ='" + id + "';";
            return dbMan.ExecuteNonQuery(query);
        }

        //public DataTable GetEmployeeData(string id)
        //{
        //    string query = "SELECT * FROM Employee WHERE ID='" + id + "'";
        //    return dbMan.ExecuteReader(query);
        //}
        //public int DeleteEmployee(string id)
        //{
        //    string query = "DELETE FROM Employee WHERE ID='" + id + "';";

        //    return dbMan.ExecuteNonQuery(query);
        //}



        public DataTable GetEmployeeData(string id)
        {
            String StoredProcedureName = StoredProcedures.GetEmployeedata;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@id", id);
            return dbMan.ExecuteReader1(StoredProcedureName, Parameters);
        }
        public int DeleteEmployee(string id)
        {

            string StoredProcedureName = StoredProcedures.Deleteemployee;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@id", id);

            return dbMan.ExecuteNonQuery1(StoredProcedureName, Parameters);
        }


        public int AddService(string name,string des)
        {
            string query = "INSERT INTO ServicesAvailable (ServiceName,ServiceDescription)" +
                            "Values ('" + name + "','" + des + "');";
            return dbMan.ExecuteNonQuery(query);
        }
        ////////////////////Receptionist Functinalities//////////
        ///
        //public int createpatientaccount(int id, string fname, string lname, int age, string gender)
        //{
        //    int pass = 1111;
        //    string query = "INSERT INTO Patient (ID,Fname,Lname,Gender,Age,Password)" +
        //                    "Values ('" + id + "','" + fname + "','" + lname + "','" + gender + "','" + age + "','" + pass + "');";
        //    return dbMan.ExecuteNonQuery(query);
        //}


        public int createpatientaccount(string id, string fname, string lname, int age, string gender)
        {
            string pass = "1111";
            string StoredProcedureName = StoredProcedures.Createpatientaccount;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@id", id);
            Parameters.Add("@fname", fname);
            Parameters.Add("@lname", lname);
            Parameters.Add("@age", age);
            Parameters.Add("@gender", gender);
            Parameters.Add("@pass", pass);
            return dbMan.ExecuteNonQuery1(StoredProcedureName, Parameters);
        }


        public DataTable Getbills(string pid)
        {
            String StoredProcedureName = StoredProcedures.Getbills;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@pid", pid);
            return dbMan.ExecuteReader1(StoredProcedureName, Parameters);
        }

        public DataTable Gettotalbill(string pid)
        {
            String StoredProcedureName = StoredProcedures.Gettotalbills;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@pid", pid);
            return dbMan.ExecuteReader1(StoredProcedureName, Parameters);
        }
        public DataTable checkPatientID(string id)
        {
            String StoredProcedureName = StoredProcedures.Checkpatientid;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@id", id);
            return dbMan.ExecuteReader1(StoredProcedureName, Parameters);
        }




        //public DataTable Getbills(int pid)
        //{
        //    string query = "SELECT Patient.ID,Patient.FName,Patient.LName,AppointmentID,cost FROM Appointments,Patient  " + "  WHERE Patient.ID=PatientID and Patient.ID='" + pid + "'  ; ";
        //    return dbMan.ExecuteReader(query);
        //}

        //public DataTable Gettotalbill(int pid)
        //{
        //    DataTable de = Getbills(pid);
        //    string query = "SELECT PatientID, SUM (cost) AS Total_Bill FROM  Appointments where PatientID='" + pid + "' group by PatientID  ;  ";
        //    // string query = " SELECT SUM (cost) as Total_Bill from de ";
        //    return dbMan.ExecuteReader(query);
        //}
        //public DataTable checkPatientID(int id)
        //{
        //    string query = " SELECT Fname from Patient " + " WHERE ID=" + id + "  ";
        //    return dbMan.ExecuteReader(query);
        //}

        ///////////////////////// STOCK MANAGER FUNCTION /////////////////////////
        //public DataTable SelectStockAvailable()
        //{
        //    string query = "SELECT DISTINCT Item_Name FROM Stock;";
        //    return dbMan.ExecuteReader(query);
        //}


        public DataTable SelectStockAvailable()
        {
            String StoredProcedureName = StoredProcedures.Selectstockavailable;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            return dbMan.ExecuteReader1(StoredProcedureName, Parameters);
        }

        public int UpdateStock(string itemname, int addedvalue)
        {
            string getcurrentStock = "SELECT Item_Qty FROM Stock where Item_Name='" + itemname + "';";
            string stockvalue = dbMan.ExecuteScalar(getcurrentStock).ToString();
            int csv = Int32.Parse(stockvalue);
            int uv = csv + addedvalue;

            string query = "UPDATE Stock SET Item_Qty=" + uv + " WHERE Item_Name='" + itemname + "';";
            return dbMan.ExecuteNonQuery(query);
        }

        //public DataTable ShowDataStock()
        //{
        //    string query = "SELECT Item_Name, Item_Qty, Minimum_Qty_Acc FROM Stock;";
        //    return dbMan.ExecuteReader(query);
        //}

        public DataTable ShowDataStock()
        {
            String StoredProcedureName = StoredProcedures.Showdatastock;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            return dbMan.ExecuteReader1(StoredProcedureName, Parameters);
        }


        public int changeemployeepass(string pass, string id)
        {
            string StoredProcedureName = StoredProcedures.Changeemployeepassword;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@id", id);
            Parameters.Add("@Password", pass);
            return dbMan.ExecuteNonQuery1(StoredProcedureName, Parameters);
        }


        ///////////////////////// DEPARTMENT CRUD FUNCTION /////////////////////////

        public int InsertDepartment(string ID, string dname, string depheadid)
        {

            string query = "INSERT INTO Departments (DepartmentID,Department_Name,Department_Head_ID)" +
                            "Values ('" + ID + "','" + dname + "','" + depheadid + "');";
            return dbMan.ExecuteNonQuery(query);
        }

        public int UpdateDepartment(string ID, string dname, string depheadid)
        {

            string query2 = "SELECT ID FROM Doctor WHERE ID='" + depheadid + "';";
            DataTable run = dbMan.ExecuteReader(query2);
            if (run != null)
            {
                string query = "Update Departments SET Department_Name ='" + dname + "',Department_Head_ID = '" + depheadid + "' WHERE DepartmentID ='" + ID + "';";
                return dbMan.ExecuteNonQuery(query);
            }
            return -1;

        }

        public int DeleteDepartment(string ID)
        {
            string query = "DELETE FROM Departments WHERE DepartmentID='" + ID + "';";
            return dbMan.ExecuteNonQuery(query);
        }

        public int UpdateDepartmentHead(string depheadID, string depID)
        {
            string query = "Update Departments SET Department_Head_ID = '" + depheadID + "' WHERE DepartmentID ='" + depID + "';";
            return dbMan.ExecuteNonQuery(query);
        }

        public int RequestAppointments(string patientid)
        {
            string query = "insert into Request_Appointment (PatientID) values ('" + patientid + "');";
            return dbMan.ExecuteNonQuery(query);
        }
        public int changereceptionistpass(string pass,string id)
        {
            string query = "Update Employee SET Password = '" +pass+ "' WHERE ID ='" + id + "';";
            return dbMan.ExecuteNonQuery(query);
        }

        public int InsertEmployeee(string id, string fname, string lname, int salary, string role, string depid, string pass)
        {
            string getSID = "SELECT Department_Head_ID FROM Departments WHERE DepartmentID='" + depid + "';";
            DataTable superi = dbMan.ExecuteReader(getSID);
            string superid = superi.Rows[0][0].ToString();


            string query = "INSERT INTO Employee (ID,Fname,Lname,Salary,Emp_Role,WorksIN_Dep,SupervisorID,Password)" +
                            "Values ('" + id + "','" + fname + "','" + lname + "'," + salary + ",'" + role + "','" + depid + "','" + superid + "','" + pass + "');";
            return dbMan.ExecuteNonQuery(query);
        }
        ///////////////////////// Reports functions /////////////////////////
        public DataTable getSalary()
        {
            string query = "SELECT Fname, Salary FROM Doctor;";
            return dbMan.ExecuteReader(query);
        }
        public DataTable getStockQ()
        {
            string query = "SELECT Item_Name,Item_Qty FROM Stock;";
            return dbMan.ExecuteReader(query);
        }

        public DataTable getCost()
        {
            string query = "SELECT AppointmentID,cost FROM Appointments;";
            return dbMan.ExecuteReader(query);
        }



        ///////////////////////// Appointments /////////////////////////
        public DataTable getDoctorID()
        {
            string query = "SELECT doctorID FROM DoctorTimeSlots;";
            return dbMan.ExecuteReader(query);
        }

        public DataTable returnSlots()
        {
            string query = "SELECT Slot1,Slot2,Slot3,Slot4,Slot5,Slot6 FROM DoctorTimeSlots;";
            return dbMan.ExecuteReader(query);
        }

        public int UpdateAppointmentReception(string DocID, string SlotNumber, bool setter, string reqid)
        {

            string query = "SELECT Slot" + SlotNumber + " FROM DoctorTimeSlots WHERE DoctorID ='" + DocID + "';";
            // SELECT Slot3 FROM DoctorTimeSlots
            bool ValueIN = (bool)dbMan.ExecuteScalar(query);
            if (ValueIN == setter)
            {
                return -1;
            }
            else
            {
                string query2;
                if (setter == true)
                {
                    query2 = "Update DoctorTimeSlots SET Slot" + SlotNumber + "=1 WHERE DoctorID = '" + DocID + "';";
                    string query3 = "";
                    if (SlotNumber == "1")
                    {
                        query3 = "UPDATE Request_Appointment SET Status ='Accepted', Requested_Time='8:00:00' WHERE RequestID='" + reqid + "';";
                    }
                    else if (SlotNumber == "2")
                    {
                        query3 = "UPDATE Request_Appointment SET Status ='Accepted', Requested_Time='10:00:00' WHERE RequestID='" + reqid + "';";
                    }
                    else if (SlotNumber == "3")
                    {
                        query3 = "UPDATE Request_Appointment SET Status ='Accepted', Requested_Time='12:00:00' WHERE RequestID='" + reqid + "';";
                    }
                    else if (SlotNumber == "4")
                    {
                        query3 = "UPDATE Request_Appointment SET Status ='Accepted', Requested_Time='14:00:00' WHERE RequestID='" + reqid + "';";
                    }
                    else if (SlotNumber == "5")
                    {
                        query3 = "UPDATE Request_Appointment SET Status ='Accepted', Requested_Time='16:00:00' WHERE RequestID='" + reqid + "';";
                    }
                    else if (SlotNumber == "6")
                    {
                        query3 = "UPDATE Request_Appointment SET Status ='Accepted', Requested_Time='18:00:00' WHERE RequestID='" + reqid + "';";
                    }
                    dbMan.ExecuteNonQuery(query3);
                }
                else
                {
                    query2 = "Update DoctorTimeSlots SET Slot" + SlotNumber + "=0 WHERE DoctorID = '" + DocID + "';";
                }
                return (int)dbMan.ExecuteNonQuery(query2);
            }
        }



        public DataTable getDepCount()
        {
            string query = "SELECT count(ID),WorksIN_Dep FROM Doctor GROUP BY WorksIN_Dep;";
            return dbMan.ExecuteReader(query);
        }



        public DataTable ReturnRequests()
        {
            //WHERE Status ='Pending'
            string query = "SELECT * FROM Request_Appointment;";
            return dbMan.ExecuteReader(query);
        }


        public DataTable getRequestID()
        {
            string query = "SELECT RequestID FROM Request_Appointment;";
            return dbMan.ExecuteReader(query);
        }

        public int UpdatesSurgeryRoom(int value, string roomid, string slotid)
        {
            string query = "Update Surgery_Rooms SET slot" + slotid + " = " + value + " WHERE Surg_Room_Numb = '"+ roomid + "';";
            return dbMan.ExecuteNonQuery(query);
        }

        public DataTable getnumber()
        {
            string query = "SELECT DoctorID, COUNT(PatientID) as NumberOfPatients FROM Appointments GROUP BY DoctorID;";
            return dbMan.ExecuteReader(query);
        }
    }
}
