   M S B A M L   `   `   `  ����  AlgoforcePayrollApp0    *AlgoforcePayrollSystem.Views.PayrollWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Payroll Operations��5   	   $	��600��6$   $	��800��61   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��10q�6.   $��0��6:   .+�5      �� $��Payroll Operations��6   $��20(�62   $
��Bold"�6@   $��Center=�6R   5      � 5   
   $��1��6   $��10q�6    � ColumnDefinitions 5      �� 5      $��2* �6#   �� 5      $��3* �6#   .+�5      �� -   5        $��EmployeeList��5      $��0��6*   $��10q�6:    �� DisplayMemberPath$
 Name��5       �� SelectedValuePath$ 
EmployeeId��6/   5      �� 5      $��1��6   $��10q�6)   .+�5      �� $ 
Horizontal=�6   $��5q�66   .+�5       �� $��Name:��6    $	��150��6-   $��Center=�69   �� 5!      -   5        $��EmployeeName��5!       $	��200��64   $��Center=�6@   5"      �� 5%      $ 
Horizontal=�6   $��5q�66   .+�5&      �� $��Hourly Rate:��6    $	��150��64   $��Center=�6@   �� 5'      -   5        $��HourlyRateInput��5'      $	��200��65   5(      �� 5)      $ 
Horizontal=�6   $��5q�66   .+�5*      �� $��Hours Worked:��6    $	��150��65   $��Center=�6A   �� 5+      -   5        $��HoursWorkedInput��5+      $	��200��66   5,      �� 5/      $ 
Horizontal=�6   $��5q�66   .+�50      �� $��Overtime Hours:��6    $	��150��67   $��Center=�6C   �� 51      -   5        $��OvertimeHoursInput��51      $	��200��68   52      �� 53      $ 
Horizontal=�6   $��5q�66   .+�54      �� $��Night Differential:��6    $	��150��6;   $��Center=�6G   �� 55      -   5        $��NightDifferentialInput��55      $	��200��6<   56      �� 59      $ 
Horizontal=�6   $��5q�66   .+�5:      �� $��De Minimis:��6    $	��150��63   $��Center=�6?   �� 5;      -   5        $��DeMinimisInput��5;      $	��200��64   5<      �� 5?      $��
Deductions��6   $��	10,10,0,0q�6/   .��5@      �� .+�5A      �� $ 
Horizontal=�6%   $��5q�6>   .+�5B      �� $��Loan:��6(   $	��150��65   $��Center=�6A   �� 5C      -   5        $��	LoanInput��5C   &   $	��200��67   5D      �� 5E      $ 
Horizontal=�6%   $��5q�6>   .+�5F      �� $��	SSS Loan:��6(   $	��150��69   $��Center=�6E   �� 5G      -	   5        $��SSSLoanInput��5G   &   $	��200��6:   5H      �� 5I      $ 
Horizontal=�6%   $��5q�6>   .+�5J      �� $��Pag-ibig Loan:��6(   $	��150��6>   $��Center=�6J   �� 5K      -
   5        $��PagIbigLoanInput��5K   &   $	��200��6>   5L      5M      5N      �� 5Q      $��	10,20,0,0q�6   .+�5R      �� $ 
Horizontal=�6!   $��5q�6:   .+�5S      �� $��Net Pay:��6$   $	��150��64   $��Center=�6@   �� 5T      -   5        $��NetPayOutput��5T   $   $	��200��68   $��Center=�6D   $
��Bold"�6_   5U      �� 5V      -   5        $��CalculatePayrollButton��5V   9   $��Calculate Payroll��6   $	��200��6W   $��5q�6c   6n   �� 5W      -   5        $��SavePayrollButton��5W   4   $��Save Payroll��6   $	��200��6M   $��5q�6Y   6d   5X      5Y      5Z      5[      5\      