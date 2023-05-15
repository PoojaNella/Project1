select * from [Portfolio Project].[dbo].[coviddeaths]
where continent is not null
order by 3,4

--select * from [Portfolio Project].[dbo].[covidvaccinations]
--order by 3,4

select location,date,total_cases,new_cases,total_deaths,population 
from [Portfolio Project].[dbo].[coviddeaths]
order by 1,2

----Total cases vs Total Deaths

select location,date,total_cases,total_deaths, (total_deaths/total_cases) * 100 As CovidDeaths
from [Portfolio Project].[dbo].[coviddeaths]
where continent is not null
--where location like '%ind%'

--Alter table covidDeaths
--Alter column population float;

---total cases vs Population
select location,date,population,total_cases,total_deaths, (total_cases/population) * 100 As Populationwithcovid
from [Portfolio Project].[dbo].[coviddeaths]
where continent is not null
--where location like '%ind%'
order by 1,2

---Countries with highest infection rate to its population.

select location,population,MAX(total_cases) as HighestInfectioncount,MAX((total_cases/population))*100 As PopulationPercentInfected
from [Portfolio Project].[dbo].[coviddeaths]
where continent is not null
Group by location,population
order by PopulationPercentInfected desc

--Showing continents with Highest Death count

select continent,MAX(total_deaths) as HighestDeathcount
from [Portfolio Project].[dbo].[coviddeaths]
where continent is not null
Group by continent
order by HighestDeathcount desc

---Global Numbers

select Sum(cast(new_cases as float)) as total_cases,sum(cast(new_deaths as float))as total_deaths, 
sum(cast(new_deaths as float))/Sum(cast(new_cases as float)) * 100 As DeathPercentage
from [Portfolio Project].[dbo].[coviddeaths]
where continent is not null
--group by date 
order by 1,2


---Joining the tables

select dea.continent, dea.location,dea.date, dea.population,vac.new_vaccinations,
sum(convert(int,vac.new_vaccinations)) over (partition by dea.location order by dea.location,dea.date)
As RollingPeoplevaccinated
from [Portfolio Project].[dbo].[CovidDeaths] as dea
join [Portfolio Project].[dbo].[CovidVaccinations] as vac
on dea.date = vac.date 
and dea.location = vac.location
where dea.continent is not null
order by 2,3 


----Creating Temp Table

Drop table if exists #Percentpopulationvaccinated
Create table #Percentpopulationvaccinated
(
continent nvarchar(255), 
location nvarchar(255),
date datetime, 
population int,
new_vaccinations int,
RollingPeoplevaccinated float
)
Insert into #Percentpopulationvaccinated
select dea.continent, dea.location,dea.date, dea.population,vac.new_vaccinations,
sum(convert(int,vac.new_vaccinations)) over (partition by dea.location order by dea.location,dea.date)
As RollingPeoplevaccinated
from [Portfolio Project].[dbo].[CovidDeaths] as dea
join [Portfolio Project].[dbo].[CovidVaccinations] as vac
on dea.date = vac.date 
and dea.location = vac.location
where dea.continent is not null

select * , (RollingPeoplevaccinated/population) *100 as percentvaccinated
from #Percentpopulationvaccinated

----creating view to store data

create view Percentpopulationvaccinated as
select dea.continent, dea.location,dea.date, dea.population,vac.new_vaccinations,
sum(convert(int,vac.new_vaccinations)) over (partition by dea.location order by dea.location,dea.date)
As RollingPeoplevaccinated
from [Portfolio Project].[dbo].[CovidDeaths] as dea
join [Portfolio Project].[dbo].[CovidVaccinations] as vac
on dea.date = vac.date 
and dea.location = vac.location
where dea.continent is not null


Create view GlobalNumbers as
select Sum(cast(new_cases as float)) as total_cases,sum(cast(new_deaths as float))as total_deaths, 
sum(cast(new_deaths as float))/Sum(cast(new_cases as float)) * 100 As DeathPercentage
from [Portfolio Project].[dbo].[coviddeaths]
where continent is not null