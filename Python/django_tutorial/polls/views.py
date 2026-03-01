from django.shortcuts import render
from django.http import HttpResponse

# Create your views here.
def index(request):
    return HttpResponse("Witaj, Swiecie. Jestes na baseny ankiety wskaznik.")