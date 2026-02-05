namespace DSA.Heap
{
    public class MinHeap
    {
        private List<(int, int)> heap;

        public int Count => heap.Count;

        public MinHeap()
        {
            heap = new List<(int, int)>();
        }

        public void Enqueue(int node, int distance)
        {
            heap.Add((node, distance));
            HeapifyUp(heap.Count - 1);
        }

        public bool TryDequeue(out int node, out int distance)
        {
            if (heap.Count == 0)
            {
                node = -1;
                distance = int.MaxValue;
                return false;
            }

            var top = heap[0];
            node = top.Item1;
            distance = top.Item2;

            heap[0] = heap[heap.Count - 1];
            heap.RemoveAt(heap.Count - 1);

            if (heap.Count > 0)
            {
                HeapifyDown(0);
            }

            return true;
        }

        private void HeapifyUp(int curIndex)
        {
            while (curIndex > 0)
            {
                int parent = (curIndex - 1) / 2;

                if (heap[parent].Item2 < heap[curIndex].Item2)
                {
                    break;
                }

                Swap(parent, curIndex);
                curIndex = parent;
            }
        }

        private void HeapifyDown(int curIndex)
        {
            while (true)
            {
                int smallest = curIndex;
                int left = 2 * curIndex + 1;
                int right = 2 * curIndex + 2;

                if (heap[smallest].Item2 > heap[left].Item2)
                {
                    smallest = left;
                }

                if (heap[smallest].Item2 > heap[right].Item2)
                {
                    smallest = right;
                }

                if (smallest == curIndex)
                {
                    break;
                }
                Swap(smallest, curIndex);
                curIndex = smallest;
            }
        }

        private void Swap(int a, int b)
        {
            (int nodeTmp, int distanceTmp) = heap[a];
            heap[a] = heap[b];
            heap[b] = (nodeTmp, distanceTmp);
        }
    }
}
