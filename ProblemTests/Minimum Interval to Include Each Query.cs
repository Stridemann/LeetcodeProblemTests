﻿namespace DefaultNamespace;

public class Minimum_Interval_to_Include_Each_Query
{
	[Theory]
	[InlineData("[[1,4],[2,4],[3,6],[4,4]]", new int[] { 2, 3, 4, 5 }, new int[] { 3, 3, 1, 4 })]
	[InlineData("[[2,3],[2,5],[1,8],[20,25]]", new int[] { 2, 19, 5, 22 }, new int[] { 2, -1, 4, 6 })]
	[InlineData(
		"[[6,6],[5,5],[10,10],[3,6],[9,9],[7,7],[2,10],[5,5],[3,7],[10,10]]",
		new int[] { 1, 8, 9, 1, 8, 3, 9, 3, 10, 1 },
		new int[] { -1, 9, 1, -1, 9, 4, 1, 4, 1, -1 })]
	[InlineData(
		"[[54,82],[55,66],[81,89],[38,67],[81,86],[47,47],[13,61],[33,39],[61,66],[97,97],[52,68],[96,98],[89,92],[1,41],[81,89],[9,57],[81,90],[41,73],[29,80],[98,98],[61,95],[93,98],[5,65],[91,96],[91,99],[28,68],[55,71],[35,45],[1,89],[48,48],[26,36],[5,83],[20,83],[73,92],[69,69],[77,89],[12,52],[5,53],[33,53],[70,83],[81,98],[69,69],[28,90],[9,77],[40,53],[53,71],[7,55],[7,28],[5,88],[61,68],[25,93],[45,73],[13,51],[27,70],[47,87],[71,91],[93,98],[1,35],[24,39],[86,90],[19,33],[1,69],[21,100],[85,85],[99,99],[25,25],[90,94],[13,61],[69,85],[89,97],[1,43],[11,35],[41,95],[31,99],[86,94],[33,63],[22,91],[61,75],[71,83],[31,85],[28,83],[1,21],[81,97],[5,29],[74,83],[33,83],[13,24],[92,94],[71,71],[59,79],[21,37],[33,87],[97,97],[34,57],[11,59],[57,62],[22,23],[13,53],[84,85],[71,80],[31,89],[21,91],[91,98],[13,36],[21,69],[41,61],[73,74],[71,81],[69,85],[31,65],[61,81],[39,54],[36,90],[1,33],[41,58],[29,71],[93,99],[1,11],[33,83],[15,47],[21,96],[65,93],[1,93],[45,87],[33,81],[15,63],[49,93],[59,59],[1,7],[81,86],[1,80],[81,81],[24,24],[47,53],[38,74],[100,100],[57,68],[71,86],[65,80],[81,83],[17,71],[76,96],[85,95],[77,77],[31,71],[9,93],[1,73],[32,44],[96,97],[30,90],[41,86],[57,81],[24,28],[5,69],[21,98],[4,95],[41,76],[61,99],[52,72],[51,67],[47,67],[81,91],[93,94],[72,72],[70,89],[68,77],[41,41],[41,77],[68,77],[65,73],[11,65],[40,94],[87,94],[95,97],[19,85],[11,26],[65,85],[77,86],[25,49],[46,77],[51,67],[29,83],[5,93],[83,99],[38,50],[73,80],[41,41],[92,100],[39,59],[81,100],[1,85],[39,78],[99,100],[12,93],[71,74],[57,63],[86,99],[28,65],[62,68],[53,77],[29,53],[97,97],[41,61],[1,88],[67,87],[85,95],[1,13],[67,73],[38,42],[1,11],[45,61],[71,73],[55,99],[75,87],[46,98],[45,93],[61,71],[31,74],[95,98],[84,90],[69,95],[67,68],[41,68],[87,94],[40,73],[93,93],[73,95],[61,73],[64,78],[4,20],[81,96],[40,48],[4,11],[40,56],[33,74],[23,80],[53,74],[30,87],[65,69],[51,86],[87,89],[46,53],[81,85],[81,97],[22,23],[1,83],[76,85],[71,71],[19,84],[21,53],[13,25],[27,53],[45,57],[1,81],[41,75],[61,77],[5,60],[82,92],[1,41],[45,98],[67,69],[96,100],[51,77],[29,53],[85,91],[49,61],[73,92],[65,74],[4,32],[73,76],[99,99],[33,73],[21,83],[77,77],[65,92],[1,53],[61,69],[41,49],[1,17],[77,98],[81,91],[25,55],[62,71],[33,83],[78,92],[87,89],[37,77],[21,49],[61,77],[5,26],[86,99],[79,87],[5,25],[79,99],[16,70],[38,86],[77,80],[13,45],[73,81],[30,95],[97,97],[13,93],[81,87],[43,75],[1,33],[71,71],[61,91],[25,87],[1,37],[66,79],[11,47],[69,92],[63,82],[5,53],[7,23],[85,90],[1,65],[29,77],[36,57],[57,72],[61,61],[47,53],[89,89],[4,34],[43,93],[19,86],[71,95],[81,89],[86,91],[63,69],[78,87],[84,96],[69,72],[69,97],[1,86],[27,85],[21,99],[96,97],[49,70],[61,91],[95,99],[8,23],[59,69],[36,94],[51,90],[87,95],[99,100],[82,99],[66,86],[37,37],[41,58],[1,78],[61,91],[87,87],[45,53],[41,41],[37,49],[11,16],[16,25],[41,51],[31,41],[23,31],[37,62],[49,59],[46,68],[77,93],[32,60],[26,56],[74,81],[33,83],[45,73],[74,91],[81,89],[17,68],[51,59],[53,57],[99,99],[76,76],[31,31],[87,94],[1,93],[1,1],[61,96],[91,91],[31,41],[24,30],[64,96],[16,52],[25,43],[53,93],[40,87],[76,76],[74,74],[24,78],[5,8],[53,71],[76,84],[61,81],[13,79],[41,77],[77,85],[90,92],[39,39],[97,97],[21,43],[81,89],[41,49],[79,89],[51,77],[9,11],[21,82],[81,91],[61,85],[1,10],[54,83],[3,15],[76,97],[57,76],[26,76],[57,75],[31,75],[46,99],[19,29],[21,57],[26,98],[54,76],[26,39],[17,17],[21,21],[85,94],[46,82],[26,67],[75,97],[29,68],[45,51],[21,39],[51,62],[58,62],[57,100],[41,73],[75,99],[84,84],[29,77],[21,23],[1,94],[91,91],[6,19],[35,58],[17,41],[46,83],[81,90],[31,31],[1,37],[25,97],[49,100],[3,6],[1,73],[93,93],[20,92],[11,41],[69,97],[53,92],[31,63],[79,79],[64,94],[1,81],[33,33],[21,37],[80,95],[16,70],[75,99],[81,91],[16,75],[49,81],[95,98],[41,69],[81,97],[99,99],[46,81],[31,50],[19,33],[41,97],[97,97],[86,99],[88,94],[70,93],[1,57],[88,95],[85,85],[73,80],[12,66],[97,97],[26,56],[5,89],[27,36],[58,87],[84,88],[25,37],[69,75],[89,98],[5,86],[77,85],[81,91],[81,85],[46,90],[39,73],[21,97],[37,85],[1,85],[26,40],[81,89],[53,77],[61,93],[7,84],[24,35],[62,98],[29,41],[77,86],[5,55],[37,93],[61,76],[8,25],[31,91],[36,90],[40,90],[31,43],[1,97],[41,81],[29,35],[7,19],[99,100],[26,85],[83,89],[29,89],[26,51],[75,89],[53,74],[93,94],[90,90],[61,93],[29,53],[45,84],[5,95],[93,97],[63,99],[46,78],[90,90],[11,80],[89,89],[50,53],[14,62],[11,83],[45,81],[79,88],[95,95],[1,53],[49,94],[58,59],[68,74],[82,85],[25,74],[18,100],[41,54],[7,15],[47,68],[47,95],[76,92],[51,56],[81,91],[71,97],[97,97],[6,91],[3,99],[84,97],[9,87],[77,88],[67,85],[80,92],[1,21],[1,29],[100,100],[11,23],[89,98],[99,99],[56,65],[11,95],[89,95],[61,90],[77,77],[51,81],[71,89],[51,97],[22,36],[35,55],[20,91],[55,89],[21,21],[39,45],[21,85],[76,95],[77,79],[82,91],[11,48],[61,61],[21,64],[81,95],[51,55],[69,98],[96,100],[96,97],[73,75],[52,52],[35,94],[1,61],[15,39],[61,65],[51,97],[51,65],[85,95],[89,100],[81,97],[49,90],[26,51],[50,71],[17,45],[87,94],[21,23],[21,48],[81,99],[51,53],[99,100],[6,52],[77,89],[50,97],[92,97],[99,99],[73,98],[49,93],[73,85],[63,93],[29,77],[90,96],[1,16],[61,75],[26,83],[45,77],[21,85],[48,56],[36,90],[9,22],[85,97],[7,79],[61,80],[53,59],[91,99],[21,86],[53,71],[60,94],[72,98],[88,97],[11,11],[89,93],[81,90],[25,67],[91,93],[86,90],[21,66],[16,89],[13,27],[68,93],[85,98],[3,49],[69,85],[99,99],[23,23],[89,97],[69,85],[13,25],[61,88],[63,85],[69,92],[69,83],[71,89],[96,97],[55,95],[41,87],[57,77],[62,68],[73,91],[35,77],[53,69],[58,60],[1,15],[76,89],[83,83],[93,93],[71,96],[10,34],[25,25],[61,61],[51,75],[26,71],[11,70],[35,35],[41,57],[63,79],[99,99],[11,62],[55,86],[81,85],[57,81],[61,81],[33,69],[61,66],[24,90],[91,93],[15,17],[87,89],[1,53],[51,88],[5,5],[81,95],[75,91],[13,40],[61,84],[33,73],[31,81],[13,30],[19,31],[87,100],[1,78],[76,83],[72,93],[85,98],[95,96],[19,63],[53,53],[74,82],[17,38],[57,97],[29,56],[81,89],[21,93],[97,99],[81,99],[73,87],[37,61],[45,62],[83,91],[17,21],[96,96],[78,82],[87,97],[85,87],[85,93],[31,31],[19,21],[11,89],[45,70],[57,83],[1,51],[46,47],[73,99],[48,83],[17,25],[80,97],[76,76],[81,85],[23,41],[41,53],[59,83],[77,89],[41,69],[53,83],[49,81],[85,93],[89,90],[58,86],[18,28],[81,81],[3,65],[3,39],[22,97],[89,98],[53,89],[73,93],[81,81],[15,17],[1,80],[5,81],[61,80],[65,79],[85,93],[29,29],[23,89],[91,92],[20,85],[31,47],[97,97],[61,91],[76,91],[88,96],[9,28],[17,17],[17,19],[55,83],[31,41],[37,77],[1,66],[29,47],[5,25],[38,83],[93,100],[21,91],[46,57],[62,84],[82,83],[39,98],[1,26],[99,100],[86,86],[41,77],[65,83],[24,91],[6,6],[61,85],[39,91],[61,91],[56,64],[75,94],[49,49],[85,87],[93,97],[61,78],[1,11],[100,100],[29,89],[53,87],[38,49],[81,97],[55,63],[31,49],[9,71],[96,96],[21,73],[72,85],[68,86],[43,58],[87,87],[37,65],[55,89],[99,100],[71,86],[53,59],[62,100],[52,85],[61,61],[99,99],[78,98],[50,65],[8,84],[36,86],[26,43],[45,81],[73,86],[49,85],[43,79],[1,1],[89,91],[51,73],[21,97],[97,98],[84,100],[81,85],[14,86],[27,41],[65,90],[85,99],[31,71],[22,49],[9,89],[71,71],[49,77],[30,69],[17,72],[70,91],[72,80],[54,83],[21,80],[97,99],[41,47],[33,59],[31,47],[62,99],[23,93],[91,91],[71,81],[77,83],[1,16],[68,76],[41,60],[1,76],[1,44],[16,100],[97,99],[81,88],[61,85],[91,96],[74,79],[29,80],[47,48],[41,86],[88,96],[41,89],[37,45],[85,96],[65,80],[16,98],[49,95],[63,65],[76,78],[96,98],[31,65],[1,61],[36,99],[6,100],[43,73],[35,73],[97,98],[18,65],[91,93],[7,79],[20,68],[51,60],[57,89],[21,40],[72,97],[13,53],[56,72],[53,92],[29,29],[78,87],[40,71],[62,81],[71,83],[51,79],[97,97],[57,61],[3,72],[85,85],[5,67],[81,91],[79,89],[27,80],[41,89],[51,56],[1,77],[51,59],[41,77],[27,27],[11,97],[37,77],[59,83],[5,65],[49,53],[26,71],[97,99],[91,95],[57,85],[48,87],[3,3],[65,77],[17,64],[41,83],[38,47],[55,78],[29,44],[80,80],[75,81],[43,81],[27,57],[1,40],[51,53],[37,38],[51,61],[32,38],[37,61],[93,95],[76,90],[79,79],[12,17],[63,71],[41,51],[24,87],[97,98],[10,36],[99,99],[37,69],[16,25],[11,29],[53,55],[58,72],[97,97],[79,99],[60,60],[52,66],[9,48],[82,97],[1,86],[47,74],[45,93],[23,47],[71,95],[81,89],[47,79],[1,57],[45,77],[99,99],[27,27],[57,77],[83,83],[1,21],[3,3],[61,73],[41,52],[65,93],[66,66],[66,100],[96,98],[90,97],[36,76],[21,43],[26,88],[21,61],[93,99],[13,67],[14,20],[1,19],[60,94],[41,62],[15,65],[95,95],[50,94],[91,96],[76,84],[51,96],[57,99],[7,18],[55,91],[63,65],[43,93],[67,85],[67,99],[76,96],[13,64],[5,95],[5,61],[33,63],[76,90],[69,100],[69,75],[13,90],[61,93],[79,99],[51,57],[41,47],[73,89],[33,38],[41,41],[57,66],[65,80],[58,86],[91,91],[45,73],[37,94],[33,89],[17,57],[49,97],[21,45],[4,81],[31,36],[51,89],[89,97],[78,79],[65,82],[97,97],[49,50],[81,99],[35,60],[93,97],[41,41],[45,99],[78,81],[47,95],[64,80],[47,77],[46,62],[41,41],[47,82],[17,17],[9,9],[77,99],[63,85],[59,92],[37,65],[23,32],[34,89],[69,77],[17,31],[7,78],[71,87],[28,59],[93,97],[45,61],[26,76],[93,93],[51,73],[26,34],[49,61],[73,73],[1,61],[33,68],[13,57],[76,88],[51,97],[7,25],[47,66],[67,76],[38,63],[15,15],[21,37],[31,87],[67,70],[1,31],[80,92],[6,13],[1,31],[59,83],[26,74],[25,53],[62,64],[79,81],[61,97],[66,79],[5,47],[45,54],[63,99],[85,87],[55,75],[41,95],[76,100],[51,67],[47,74],[65,87],[14,55],[5,34],[99,99],[93,99],[41,73],[76,89],[75,77],[41,61],[56,87],[93,97],[65,78],[84,91],[2,84],[61,78],[11,13],[73,78],[46,57],[60,84],[33,42],[29,71],[97,99],[57,73],[41,53],[93,100],[19,25],[47,59],[11,11],[49,89],[21,23],[31,77],[79,83],[47,47],[20,56],[19,47],[57,57],[80,100],[6,51],[95,95],[9,99],[23,49],[20,72],[76,81],[49,54],[65,65],[43,59],[30,75],[50,77],[95,98],[2,25],[2,35],[77,77],[29,83],[8,46],[81,85],[97,97],[41,53],[16,35],[19,77],[6,46],[33,50],[71,98],[47,65],[69,75],[21,46],[29,99],[45,97],[21,37],[8,63],[1,23],[69,93],[27,38],[86,92],[14,80],[81,86],[76,81],[87,93],[76,80],[35,61],[13,90],[23,63],[30,73],[47,53],[5,50],[49,65],[61,85],[61,67],[36,73],[89,99],[33,33],[44,47],[63,86],[33,43],[38,56],[99,99],[17,17],[29,47],[51,86],[1,9],[41,65],[4,22],[66,76],[25,29],[1,5],[96,97],[75,89],[3,45],[61,85],[78,97],[81,97],[54,90],[79,82],[38,41],[1,75],[61,69],[25,29],[75,78],[37,59],[33,44],[90,93],[25,85],[41,75],[76,77],[86,95],[65,65],[58,58],[21,86],[59,73],[41,41],[7,64],[41,93],[77,78],[60,60],[11,71],[97,98],[68,96],[99,99],[93,99],[59,65],[81,100],[31,59],[31,37],[85,91],[36,57],[31,54],[90,92],[21,73],[39,47],[71,93],[33,89],[13,21],[63,95],[39,75],[65,65],[21,81],[13,53],[21,37],[1,61],[29,77],[61,97],[25,73],[51,51],[35,65],[54,100],[85,85],[57,95],[41,49],[11,33],[15,18],[50,71],[98,98],[86,98],[51,61],[77,93],[34,98],[88,95],[5,7],[13,57],[49,53],[32,50],[83,84],[39,60],[44,61],[7,29],[31,71],[81,81],[1,83],[46,86],[35,83],[7,65],[81,83],[91,91],[93,95],[73,73],[36,53],[17,49],[56,74],[61,72],[13,13],[12,78],[29,29],[1,91],[72,72],[44,80],[45,92],[70,71],[95,97],[99,99],[76,80],[94,94],[1,77],[28,65],[8,39],[27,44],[40,40],[63,67],[41,49],[11,35],[46,91],[7,25],[13,34],[77,80],[25,83],[41,89],[93,99],[10,85],[1,23],[84,97],[69,97],[45,61],[81,89],[65,92],[1,1],[35,79],[45,94],[37,85],[31,69],[5,5],[94,94],[1,21],[13,56],[33,67],[18,64],[74,89],[1,6],[1,37],[14,65],[11,11],[12,58],[73,97],[51,89],[54,82],[33,60],[21,41],[79,93],[1,31],[16,30],[37,89],[79,91],[1,11],[75,81],[29,59],[40,77],[97,97],[88,96],[59,85],[61,77],[73,83],[59,91],[81,81],[81,99],[26,50],[25,37],[31,79],[61,87],[93,93],[21,58],[73,73],[51,61],[73,73],[25,38],[46,92],[1,16],[15,100],[5,56],[67,83],[11,11],[61,71],[81,97],[17,35],[61,80],[17,23],[57,85],[21,71],[17,93],[81,83],[98,98],[61,89],[93,96],[38,82],[85,97],[85,91],[98,100],[37,86],[57,97],[1,7],[59,87],[57,93],[46,73],[21,98],[21,25],[87,91],[13,89],[31,65],[41,41],[42,99],[81,91],[91,91],[95,99],[26,72],[30,30],[16,31],[91,92],[16,93],[45,53],[70,99],[7,42],[1,46],[93,98],[26,64],[23,29],[88,100],[76,96],[3,92],[51,83],[1,99],[41,68],[17,100],[13,13],[25,53],[80,96],[99,99],[97,97],[97,97],[81,96],[21,61],[17,49]]",
		new int[]
		{
			31, 22, 57, 57, 33, 38, 71, 1, 45, 5, 21, 88, 86, 55, 22, 32, 15, 21, 58, 51, 57, 71, 31, 45, 81, 46, 1,
			66, 77, 35, 37, 61, 17, 70, 45, 98, 67, 1, 74, 77, 21, 99, 41, 99, 5, 1, 21, 100, 99, 25, 37, 49, 96,
			60, 13, 36, 61, 13, 93, 81, 63, 89, 21, 74, 77, 97, 18, 18, 57, 100, 77, 89, 8, 33, 77, 77, 21, 98, 46,
			91, 66, 45, 21, 45, 82, 1, 1, 19, 81, 49, 61, 66, 11, 87, 99, 9, 47, 31, 85, 80, 50, 67, 97, 51, 45, 27,
			25, 30, 7, 66, 65, 73, 46, 97, 71, 7, 73, 2, 75, 29, 16, 75, 83, 61, 81, 17, 85, 91, 23, 73, 29, 93, 23,
			49, 49, 57, 71, 61, 94, 17, 89, 15, 87, 25, 17, 41, 66, 91, 21, 20, 71, 3, 76, 77, 81, 1, 11, 15, 85,
			19, 93, 45, 18, 65, 1, 76, 62, 5, 86, 31, 70, 4, 36, 55, 67, 26, 69, 69, 69, 69, 41, 21, 8, 14, 50, 1,
			41, 31, 25, 21, 38, 26, 27, 49, 76, 69, 88, 2, 93, 95, 11, 71, 48, 62, 76, 85, 9, 26, 67, 4, 61, 16, 71,
			41, 27, 21, 73, 96, 29, 11, 76, 31, 69, 61, 11, 76, 5, 57, 13, 63, 63, 85, 33, 41, 37, 11, 85, 57, 51,
			44, 16, 27, 9, 37, 34, 5, 100, 51, 97, 93, 26, 71, 3, 5, 29, 97, 35, 71, 21, 21, 97, 37, 1, 71, 41, 15,
			16, 41, 86, 31, 12, 33, 1, 31, 50, 86, 36, 96, 71, 77, 20, 91, 1, 93, 52, 25, 42, 37, 3, 7, 71, 31, 45,
			80, 86, 61, 69, 81, 69, 1, 100, 17, 41, 15, 57, 51, 13, 21, 15, 19, 46, 1, 21, 51, 82, 33, 93, 1, 71,
			51, 89, 41, 23, 1, 27, 49, 59, 31, 30, 59, 34, 1, 33, 49, 91, 17, 9, 49, 51, 93, 92, 39, 72, 71, 81, 1,
			51, 81, 50, 61, 99, 64, 41, 41, 17, 25, 57, 61, 1, 51, 52, 46, 88, 84, 61, 81, 16, 63, 55, 89, 1, 81,
			97, 20, 37, 58, 83, 11, 46, 61, 25, 45, 1, 89, 89, 13, 48, 21, 42, 73, 31, 51, 35, 34, 21, 61, 77, 49,
			5, 69, 81, 11, 51, 57, 36, 41, 7, 18, 1, 81, 43, 1, 77, 61, 45, 14, 23, 25, 67, 98, 61, 57, 46, 85, 60,
			84, 65, 3, 16, 13, 99, 12, 6, 26, 32, 49, 41, 5, 25, 61, 49, 81, 30, 48, 53, 61, 61, 77, 39, 26, 10, 96,
			69, 25, 67, 41, 32, 73, 33, 1, 5, 8, 79, 21, 1, 11, 1, 96, 16, 61, 57, 12, 82, 21, 21, 41, 61, 81, 63,
			26, 41, 33, 77, 61, 57, 17, 11, 25, 21, 17, 63, 6, 61, 4, 49, 74, 29, 11, 54, 21, 23, 93, 81, 91, 93,
			81, 97, 86, 51, 41, 16, 9, 93, 13, 82, 52, 7, 81, 87, 41, 21, 98, 66, 54, 5, 85, 61, 93, 46, 85, 21, 62,
			85, 61, 21, 92, 58, 4, 53, 41, 63, 59, 89, 92, 1, 60, 1, 11, 73, 31, 66, 13, 33, 99, 89, 96, 72, 78, 16,
			51, 9, 62, 17, 28, 97, 29, 61, 93, 29, 37, 11, 97, 8, 45, 88, 13, 69, 17, 8, 51, 89, 41, 49, 1, 15, 99,
			96, 57, 11, 55, 41, 93, 23, 35, 33, 5, 9, 83, 45, 61, 50, 97, 17, 19, 33, 19, 61, 1, 19, 22, 9, 71, 65,
			89, 85, 15, 2, 53, 27, 57, 93, 33, 47, 60, 55, 1, 19, 17, 73, 9, 49, 41, 85, 85, 79, 69, 17, 61, 87, 15,
			81, 41, 45, 81, 13, 94, 9, 9, 41, 31, 60, 23, 95, 73, 89, 33, 40, 1, 85, 3, 19, 61, 81, 41, 30, 37, 99,
			41, 33, 91, 86, 45, 17, 18, 87, 21, 13, 1, 34, 57, 83, 81, 89, 13, 48, 13, 39, 1, 93, 34, 83, 3, 19, 53,
			56, 79, 1, 83, 81, 100, 7, 45, 93, 81, 41, 55, 29, 2, 29, 64, 17, 11, 18, 40, 71, 64, 19, 41, 4, 77, 41,
			70, 49, 33, 49, 27, 26, 25, 41, 90, 53, 9, 67, 31, 76, 5, 70, 49, 80, 81, 45, 73, 67, 44, 41, 44, 17,
			81, 71, 89, 87, 69, 1, 61, 9, 49, 25, 49, 31, 1, 40, 21, 16, 81, 1, 69, 18, 21, 61, 24, 8, 3, 69, 4, 29,
			51, 9, 9, 79, 80, 67, 24, 37, 44, 11, 80, 13, 67, 26, 53, 53, 37, 61, 62, 6, 33, 9, 21, 45, 9, 57, 1,
			62, 71, 59, 81, 26, 1, 97, 66, 29, 71, 76, 93, 30, 31, 85, 38, 42, 59, 81, 97, 90, 81, 14, 1, 81, 74,
			29, 21, 97, 5, 31, 22, 69, 65, 97, 26, 91, 52, 64, 76, 85, 79, 29, 43, 61, 8, 8, 69, 55, 15, 77, 54, 16,
			41, 93, 7, 53, 17, 18, 89, 31, 65, 73, 44, 78, 71, 25, 91, 89, 92, 73, 41, 19, 70, 29, 1, 41, 70, 96,
			77, 28, 51, 70, 5, 91, 34, 29, 3, 88, 24, 95, 53, 75, 95, 1, 67, 94, 50, 57, 61, 27, 46, 27, 97, 54, 37,
			49, 85, 14, 60, 5, 21, 1, 8, 77, 57, 5, 74, 97, 57, 89, 73, 81, 65, 25, 1, 8, 59, 51, 51, 21, 69, 98,
			69, 37, 59, 66, 64, 79, 11, 17, 61, 67, 37, 1, 21, 47, 11, 85, 27, 33, 37, 53, 85, 27, 19, 79, 49, 41,
			51, 37, 93, 16, 27, 11, 5, 35, 40, 41, 46, 89, 92, 73, 95, 70, 82, 34, 9, 9, 26, 81, 89, 12, 16, 76, 21,
			7, 73, 41, 100, 82, 61, 73, 80, 97, 91, 31, 80
		},
		new int[] { -1, 9, 1, -1, 9, 4, 1, 4, 1, -1 })]
	public void Test(
		string a1,
		int[] q,
		int[] result)
	{
		var s = new Solution();
		var arr1 = ArrayUtils.ArrayFromStr(a1);
		var resultA = s.MinInterval(arr1, q);
		resultA.ShouldBe(result);
	}
}

public class Solution
{
	private class Group
	{
		public int Start;
		public int End;
		public int Min;

		public Group(
			int start,
			int end,
			int min)
		{
			Start = start;
			End = end;
			Min = min;
		}
	}

	public int[] MinInterval(int[][] intervals, int[] queries)
	{
		var q = queries.Length;
		var indexDict = new int[q][];
		var index = 0;
		foreach (var query in queries)
		{
			indexDict[index] = new int[2] { query, index };
			index++;
		}

		Array.Sort(indexDict, (a, b) => a[0] - b[0]);
		Array.Sort(intervals, (a, b) => a[0] - b[0]);

		var pq = new PriorityQueue<int[], int>();
		var result = new int[queries.Length];

		index = 0;
		foreach (var query in indexDict)
		{
			while (index < intervals.Length && intervals[index][0] <= query[0])
			{
				var curr = intervals[index];
				var size = curr[1] - curr[0] + 1;
				pq.Enqueue(new int[] { size, curr[1] }, size);
				index++;
			}

			while (pq.Count > 0 && pq.Peek()[1] < query[0])
			{
				pq.Dequeue();
			}

			result[query[1]] = pq.Count > 0 ? pq.Peek()[0] : -1;
		}

		return result;
	}

	//public int[] MinInterval(int[][] intervals, int[] queries)
	//{
	//	var sortedQueries = queries.Select((x, y) => new ValueTuple<int, int>(x, y)).OrderBy(x => x.Item1).ToList();
	//	Array.Sort(intervals, (a, b) => a[0] - b[0]);

	//	var result = new int[queries.Length];
	//	Array.Fill(result, int.MaxValue);

	//	var endDict = new Dictionary<int, Group>();
	//	var groups = new List<Group>();
	//	var curQ = new List<ValueTuple<int[], int>>();

	//	for (int i = 0; i < intervals.Length; i++)
	//	{
	//		while (i < intervals.Length - 1 && intervals[i][0] == intervals[i + 1][0])
	//		{
	//			var curInterval = intervals[i];
	//			var sum = curInterval[1] - curInterval[0] + 1;
	//			curQ.Add(new(curInterval, sum));
	//		}

	//		var groupEnd = curQ.Min(x => x.Item1[1]);
	//		var min = curQ.Min(x => x.Item2);
	//		var newGroup = new Group(intervals[i][0], groupEnd, min);
	//		groups.Add(newGroup);
	//	}

	//	//var curQ = new Queue<ValueTuple<int[], int>>();
	//	//var currentQ = sortedQueries[0];
	//	//for (int i = 0; i < intervals.Length; i++)
	//	//{

	//	//	var nextStop = 
	//	//}

	//	for (var i = 0; i < result.Length; i++)
	//	{
	//		if (result[i] == int.MaxValue)
	//			result[i] = -1;
	//	}

	//	return result;
	//}
}

/*
 * public int[] MinInterval(int[][] intervals, int[] queries)
   {
   var sortedQueries = queries.Select((x, y) => new ValueTuple<int, int>(x, y)).OrderBy(x => x.Item1).ToList();

   var result = new int[queries.Length];
   Array.Fill(result, int.MaxValue);

   foreach (var interval in intervals)
   {
   var start = interval[0];
   var end = interval[1];

   var left = 0;
   var right = sortedQueries.Count - 1;

   while (left <= right)
   {
   var mid = (left + right) / 2;
   var cur = sortedQueries[mid];
   var query = cur.Item1;

   if (start > query)
   {
   left = mid + 1;
   }
   else
   {
   right = mid - 1;
   }
   }

   for (int i = left; i < sortedQueries.Count; i++)
   {
   var query = sortedQueries[i];
   if (query.Item1 > end)
   {
   break;
   }

   var size = end - start + 1;
   if (result[query.Item2] > size)
   {
   result[query.Item2] = size;
   }
   }
   }

   for (var i = 0; i < result.Length; i++)
   {
   if (result[i] == int.MaxValue)
   result[i] = -1;
   }

   return result;
   }
 * */