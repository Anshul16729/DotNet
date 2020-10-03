<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="form.aspx.cs" Inherits="assignment.form" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function ValidateModuleList(source, args) {

            var chkListModules = document.getElementById('<%= EducationCheckBoxList.ClientID %>');

            var chkListinputs = chkListModules.getElementsByTagName("input");

            for (var i = 0; i < chkListinputs.length; i++) {

                if (chkListinputs[i].checked) {

                    args.IsValid = true;

                    return;

                }
            }
            args.IsValid = false;
        }

    </script>

     <style type="text/css">
        body{
            display:flex;
            justify-content:center;
            align-items:center;
            font-weight:bold;
        }
        .auto-style2 {
            width: 50%;
            min-height: 500px;
           border:5px solid black;
          background-color:darkseagreen;
          min-height:500px;       
        }
        .auto-style3 {
            width: 105px;
            font-size: 1.5rem;          
        }

        .auto-style4 {
            text-align:center;            
        }
        .auto-style5 {
            width: 105px;
            height: 78px;
            font-size: 1.5rem;         
        }
        .auto-style6 {
            height: 78px;
            width: 271px;
              font-size: 1.5rem;
           
        }
        .auto-style7 {
            width: 271px;
            font-size: 1.5rem;
        }
        .auto-style8 {
            height: 38px;
             font-size: 1.5rem;  
        }
        .auto-style9 {
            width: 105px;
            height: 38px;
              font-size: 1.5rem;          
        }
        .auto-style10 {
            width: 271px;
            height: 38px;
             font-size: 1.5rem;
        }

        #SaveButton{
            font-size:1.3rem;
            border:2px solid black;
            border-radius:5px;
            cursor:pointer;
        }

        #SaveButton:hover {
            background-color:grey;
        }
        #CityDropDownList{
            font-size:1.3rem;
        }
        .auto-style11 {
            height: 38px;
            font-size: 1.5rem;
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
         <table cellpadding="4" cellspacing="4" class="auto-style2">
            <tr>
                <td colspan="2" class="auto-style4">
                   <u><h1>Registration Form</h1></u> 
                </td>
            </tr>
            <tr>
                <td class="auto-style3">Name<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="NameTextBox" Display="Dynamic" ErrorMessage="Please Enter Name" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                </td>
                <td class="auto-style7">
                    <asp:TextBox ID="NameTextBox" runat="server" OnTextChanged="TextBox1_TextChanged" Width="200px" Height="25px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">Age<asp:RequiredFieldValidator ID="AgeRequiredFieldValidator2" runat="server" ControlToValidate="AgeTextBox" Display="Dynamic" ErrorMessage="Age is required" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="AgeRegularExpressionValidator1" runat="server" ControlToValidate="AgeTextBox" Display="Dynamic" ErrorMessage="Only Numeric Value" ForeColor="Red" SetFocusOnError="True" ValidationExpression="\d+">*</asp:RegularExpressionValidator>
                    <asp:RangeValidator ID="AgeRangeValidator" runat="server" ControlToValidate="AgeTextBox" Display="Dynamic" ErrorMessage="Age should be greater than 20 and less than 99" ForeColor="Red" MaximumValue="99" MinimumValue="21" SetFocusOnError="True" Type="Integer">*</asp:RangeValidator>
                </td>
                <td class="auto-style7">
                    <asp:TextBox ID="AgeTextBox" runat="server" Width="200px" Height="25px"> </asp:TextBox>
&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">Gender</td>
                <td class="auto-style7">
                    <asp:RadioButton ID="FemaleRadioButton" runat="server" GroupName="GenderGroup" Text="Female" />
&nbsp;<asp:RadioButton ID="MaleRadioButton" runat="server" GroupName="GenderGroup" Text="Male" />
                </td>
            </tr>
            <tr>
                <td class="auto-style5">Education<asp:CustomValidator runat="server" ID="cvmodulelist" ClientValidationFunction="ValidateModuleList" Display="Dynamic" ErrorMessage="Please select Education" Text="*" ForeColor="Red">
</asp:CustomValidator>
                   
                </td>
                <td class="auto-style6">
                    <asp:CheckBoxList ID="EducationCheckBoxList" runat="server" RepeatDirection="Horizontal" Width="200px" Height="25px" OnSelectedIndexChanged="EducationCheckBoxList_SelectedIndexChanged">
                        <asp:ListItem Text="10th" Value="1">&nbsp;</asp:ListItem>
                        <asp:ListItem Text="12th" Value="2">&nbsp;</asp:ListItem>
                        <asp:ListItem Text="Degree" Value="3">&nbsp;</asp:ListItem>
                        <asp:ListItem Text="Masters" Value="4"></asp:ListItem>
                    </asp:CheckBoxList>
                   
&nbsp;&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style9">City<asp:RequiredFieldValidator InitialValue="--Select City--" ID="CityRequiredFieldValidator" runat="server" ControlToValidate="CityDropDownList" Display="Dynamic" ErrorMessage="City is Required" ForeColor="Red" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                </td>
                <td class="auto-style10">
                    <asp:DropDownList ID="CityDropDownList" runat="server" OnSelectedIndexChanged="CityDropDownList_SelectedIndexChanged">
                        <asp:ListItem>--Select City--</asp:ListItem>
                        <asp:ListItem >Jaipur</asp:ListItem>
                        <asp:ListItem >Noida</asp:ListItem>
                        <asp:ListItem >Delhi</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr> 
            <tr>
                <td class="auto-style11" colspan="2">
                    <asp:Button ID="SaveButton" runat="server" OnClick="SaveButton_Click" Text="Save" Width="90px" />
                </td>
            </tr> 
            <tr>
                <td colspan="2" class="auto-style8">
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" BackColor="Silver" Font-Size="Large" ForeColor="Red" CssClass="auto-style4" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
