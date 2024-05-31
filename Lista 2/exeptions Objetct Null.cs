using System;
using System.Collections.Generic;
public class Main {
    public static void main(String[] args) {
        try {
            Object o = null;
            o.toString();
        } catch (NullPointerException e) {
            System.out.println("Erro ao tentar chamar o metodo toString() em uma referência nula.");
        }
    }
}
