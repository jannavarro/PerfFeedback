   M S B A M L   `   `   `  ����N  JPerfFeedback.Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullV>clr-namespace:PerfFeedback.Client;assembly=PerfFeedback.ClientPerfFeedback.Client  5   	    PerfFeedback   PerfFeedback.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Mvm>clr-namespace:PerfFeedback.Client;assembly=PerfFeedback.Client     5   	   -   5          � Title$  Feedbacks for CoWorkers��5   	   $��329.51��5   	   $��505.059��6    � WindowStartupLocation$ CenterScreen=�5   	    � 	Resources 5       �� 
TargetType �� Property �� Value��%Y   '��       �� 5
   
   " ��6   .�5      ��  � ��$
 Left=�6;   6J   5      5      .��5      � $
��Left=�6   $	��484��6&   $��0,0,0,2q�62    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   $	��386��6,   �� 5      $
��Auto �6   $	��305��6,   .+�5   
   �� -   5        $
��Left=�5      $	��248��5      $��	19,30,0,0q�5      $	��Top=�5      $	��347��5      ��5      �� *Items+ �� SelectedItem 5      �� *SelectedItem+ �� View 5      �� 5      .P�5      �� $
��Name��6%   	 �� Width$		 300��5!   %   
 �� DisplayMemberBinding
 5    %   ��  �� Path$
 Name�5!   %   5"      5$      �� 5&   
   $	��Add��6   $
��Left=�5(      $��	10,30,0,0q�6,   $	��Top=�6?   $��75��6W   $��22��6c   $��1��6o   ��5'      �� *
AddCommand+5(   o   �� 5)   
   $
��Edit��6   $
��Left=�5+      $��	10,67,0,0q�6,   $	��Top=�6?   $��75��6W   $��22��6b   $��1��6n   ��5*      �� *EditCommand+5+   n   5,      5.      