   M S B A M L   `   `   `  ����J  FEmployeeTesting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:EmployeeTesting.View.TestViewEmployeeTesting.View.TestView  5      /    )EmployeeTesting.View.TestView.TestingPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      =local+clr-namespace:EmployeeTesting.View.TestView     5        N� Title$  TestingPage��5	      .��5      �  � ColumnDefinitions 5   
   �� 5      $	��200 �6   �� 5       � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      �� 5      $
��Auto �6   .+�5   
   �� $��2��6   $��Center=�6(   $��5q�6E   $��20(�6l   ��6P   �� *
Test_Title+6l   �� 5   
   $��Сотрудник��6    	  Label#��[  6%   $��1��6D   �� 5   
   -   5         ��Name$ EmployeeComboBox��5   d   $��5,5,60,5q�6    �� DisplayMemberPath$ FullName��6%   $��1��6~   $��1��6�    �� SelectedItem 6B   �� *
Employee+6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ QuestionsData��5   ~   $��2��6   $��5q�6'   $��2��62      HeadersVisibility$
 None=�6e   ��6?   �� *Test_Question+   Columns 5      4  .System.Windows.Controls.DataGridTemplateColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 * 6)   
   CellTemplate
 5      �� 5      .R�5       � $��0,0,0,15q�6#    5!   "   �� 5"   &   $	��200 �67   �� 5#   &    5%   "   �� 5&   &   $
��Auto �64   �� 5'   &   .+�5)   "   �� $��2��6,   $
��Auto��6Z   #��[  6g   $
��Wrap=�6�   ��6@   �� *
Question+6�   �� 5*   "   $��1��6,   $��Ваш ответ:��69   $��Center=�6K   #��[  6f   �� 5,   "   $��5q�6*    �� AcceptsReturn . $��1��6�    �� TextWrapping$
 Wrap=�6�   $	��100��6�   $��1��6�   ��6J   �� *
UserAnswer+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6�   5-      5.      50      52      �� 54   
   -   5         ��Name$ SaveBtn��54      $��Сохранить��69   $��3��6M   $��Right=�6Z   $��2��6v   55      56      