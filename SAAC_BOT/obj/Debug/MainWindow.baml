   M S B A M L   `   `   `  ����C  ?SAAC_BOT, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:SAAC_BOTSAAC_BOT  5   	       SAAC_BOT.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:SAAC_BOT     5   	   -   5          �Name$  	mainFrame��5   	    � Title$
 SAAC��5   	   $	��757��6   $	��640��6#    � 
ResizeMode$ CanMinimize=�6/    � Icon$ saaclogo.png��6H   ��5	      �� 5
   
    �� ImageSource$# Blurry-iphone-6-wallpaper.jpg��6   .��5      �� -   5         ��Name$ superCanvas��5      $
��Left=�6"   $	��655��6=   $	��Top=�6J   $	��630��6b   .+�5   
   �� -   5         ��Name$ saacLogo��5      $��
��6#   $	��120��63    �� Left$ 10��6@   $	��120��6Q   $��0q�6]   
 �� Top$ 10��6q      CustomButtonStyle#��[  6�   ��5      �� 5      $ saaclogo.png��6   5      �� 5   
   -   5        $ 	vozCanvas��5      $
��Left=�6$   $	��726��6?   $	��Top=�6L   $	��630��6d   .+�5      �� -   5        $ btnChat��5      $��
��6&   $��80��66   $	 540��6B   $ 10��6T   $��80��6d   	 � Cursor$
	 Hand��6o   $��Segoe UI Light)�6}   $��18(�6�   
���   �$��0q�6�   #��[  6�   ��5      �� 5      $ speech-bubble.png��6!   5      �� 5      -   5        $ btnVoz��5      $�� ��6%   $	��126��60   $	 257��6=   $	 578��6O   $	��125��6`   
 J� RenderTransformOrigin$
 0.5,0.5&�6l   $��0q�6�   $
	 Hand��6�   #��[  6�   ��6�   Z� ��5      �� 5      $ 	logob.png��6!    �� RelativeTransform 5      V� 5      .~�5   "   ��  �� ScaleY$ 1Q�61    �� ScaleX$ 1Q�6<   �� 5   "    �� AngleY$ 0Q�60    �� AngleX$ 0Q�6;   �� 5    "    �� Angle$ 0Q�62   T� 5!   "   5"      5$      5&      �� 5'      -   5         ��Name$ txtConversacionVoz��5'      $	��416��62   $ 10��6?    �� TextWrapping$
 Wrap=�6P   $2��,




        ¿Qué puedo hacer hoy por ti?
��6d   $	 135��6�   $	��610��6�   $��0q�6�   $��Segoe UI Light)�6�   $��36(�6  
���   �|�.  $��Italic$�6E  ��6�   Z� 6E  �� 5(      -   5        $ 
btnInfoVoz��5(      $��
��6)   $��50��69   $	 570��6E   $	 654��6W   $��50��6h   $��0q�6s   #��[  6�   $
	 Hand��6�   ��5)      �� 5*      $ info-button.png��6!   5,      �� 5-      -	   5         ��Name$ txtHeaderVoz��5-      $��47��6.   $	 213��6:   $
��Wrap=�6L   $ 43��6`   $	��246��6p   $��Segoe UI Light)�6|   $��30(�6�   �� 6�   $�Bienvenido ��6�   �� 6�   $�a ��6�   �� 6�   $
�SAAC��6�   �� 6�   �� 6�   6�   5.      �� 5/   
   -
   5        $ 
chatCanvas��5/      $
��Left=�6%   $��924.5��6@   $	��Top=�6O   $	��630��6g   $y�Hidden=�6s   .+�50      �� -   5        $ 
btnVozChat��50      $��
��6)   $��80��69   $	 540��6E   $ 10��6W   $��80��6g   $
	 Hand��6r   $��Segoe UI Light)�6�   $��18(�6�   
���   �$��0q�6�   #��[  6�   ��51      �� 52      $ 	logob.png��6!   54      �� 55      -   5        $ btnEnviarPregunta��55      $�� ��60   $��60��6;   $	 570��6G   $ 705.5��6Y   $��50��6l   $
 0.742,1.583&�6w   $��0q�6�   $
	 Hand��6�   #��[  6�   ��6�   Z� ��56      �� 57      $ send.png��6!    58      V� 59      .~�5:   "   �� $ 1Q�61   $ 1Q�6<   �� 5;   "   $ 0Q�60   $ 0Q�6;   �� 5<   "   $ 0Q�62   T� 5=   "   5>      5@      5B      �� 5C      -   5        $ txtConversacionChat��5C      $	��543��63   $ 10��6@   $
 Wrap=�6Q   $,��&Zack: Hola. ¿En qué puedo ayudarte?
��6e   $ 157.5��6�   $	��610��6�   $��0,0,0,1q�6�   $��Segoe UI Light)�6�   $��30(�6   
���   �|�.  $��Italic$�64  ��6�   Z� 64  �� 5D      -   5        $ btnInfoChat��5D      $��
��6*   $��50��6:   $	 570��6F   $	 864��6X   $��50��6i   $��0q�6t   #��[  6�   $
	 Hand��6�   ��5E      �� 5F      $ info-button.png��6!   5H      �� 5I      -   5        $ txtHeaderChat��5I      $��47��6/   $ 304.5��6;   $
��Wrap=�6O   $ 43��6c   $��72��6s   $��Segoe UI Light)�6~   $��30(�6�   $
��Chat��6�   �� 5J      -   5        $ txtPreguntas��5J      $��60��6,   $ 10��68   $
 Wrap=�6I   $��Ocupo...��6]   $ 705.5��6m   $	��555��6�   $��Segoe UI Light)�6�   $��20(�6�   
���   �$��0,0,1,0q�6�   $��0q�6�   ��6�   Z� 6  5K      �� 5L   
   -   5        $ ayudaCanvas��5L      $
��Left=�6&   $��924.5��6A   $	��Top=�6P   $	��630��6h   $y�Hidden=�6t   .+�5M      �� -   5        $ btnAtrasAyuda��5M      $��
��6,   $��50��6<   $	 570��6H   $	 864��6Z   $��50��6k   $��0q�6v   $
	 Hand��6�   #��[  6�   ��5N      �� 5O      $ left-arrow.png��6!   5Q      �� 5R      -   5        $ txtHeaderAyuda��5R      $
��Wrap=�60   $��79.45��6D   $��Segoe UI Light)�6R   $��30(�6n   
���   �$��47��6�   $ 281.296��6�   $ 40��6�   �� 6�   $�Ayuda��6�   �� 6�   �� 6�   6�   � 5S      $	��708��6   $ 10��6    $	 133��61   $	��610��6B    � RowDefinitions 5T      �� 5U      $
��Auto �6$   �� 5V      $
��Auto �6$   �� 5W      $
��Auto �6$   �� 5X      $
��Auto �6$   �� 5Y      $
��Auto �6$   �� 5Z      $
��Auto �6$   .+�5\      9� $��¿Qué es SAAC?��6   $��20(�62   $��10,10,10,10q�6@   .��5]      �� $����El SAAC es un sistema automatizado de atención a clientes que responde preguntas frecuentes de Microsoft Word por medio de voz o texto.��6    $
��Wrap=�6�    �� TextAlignment$ Justify=�6�   5^      9� 5_      $'��!¿Cómo puedo hacer una pregunta?��6   $��20(�6D   $��10,10,10,10q�6R   $��1��6g   .��5`      �� $����Actualmente se pueden realizar preguntas vía voz o texto.                                -Voz: Haga click en el botón de microfono y diga la palabra 'Hey Zack' seguida de su pregunta.                                                                -Texto: Haga cick en el icono de chat en la parte superior, e ingerese su pregunta en la caja de texto en la parte de abajo��6    $
��Wrap=�6�  5a      9� 5b      $8��2¿El sistema siempre está escuchando lo que digo?��6   $��20(�6U   $��10,10,10,10q�6c   $��2��6x   .��5c      �� $P��JNo, el sistema solo escucha cuando se le da click al botón de micrófono.��6    $
��Wrap=�6p   5d      9� 5e      $:��4¿Si no se respondió mi pregunta, qué puedo hacer?��6   $��20(�6V   $��10,10,10,10q�6d   $��3��6y   .��5f      �� $����En caso de que el sistema no pueda reconocer su pregunta, se le contactará con una persona de servicio a cliente para que le aclare su duda.��6    $
��Wrap=�6�   5g      9� 5h      $<��6No tengo micrófono, ¿Cómo puedo realizar preguntas?��6   $��20(�6X   $��10,10,10,10q�6f   $��4��6{   .��5i      �� $\��VSi no cuenta con micrófono, puede realizar preguntas por texto en la ventana de chat.��6    $
��Wrap=�6}   5j      5k      5l      5m      5n      